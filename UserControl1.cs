using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agentie_Pariuri
{
    public partial class UserControl1 : UserControl
    {
        public List<Image> images;
        public PictureBox pictureBox;
        public int index;
        private string connString;
        public bool IsImageDropAllowed { get; private set; }
        public UserControl1()
        {
            InitializeComponent();
            connString= @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path.Combine(Application.StartupPath, "database_pariuri.accdb");
            DragEnter += UserControl1_DragEnter;
            DragDrop += UserControl1_DragDrop;

            pictureBox1.SizeMode=PictureBoxSizeMode.AutoSize;

            images = new List<Image>();
            index = -1;
            IsImageDropAllowed = false;

            LoadImagesFromDatabase();
        }

        public void SetImageDropAllowed(bool allowed)
        {
            IsImageDropAllowed = allowed;
        }

        private async void UserControl1_DragDrop(object sender, DragEventArgs e)
        {
            if (IsImageDropAllowed)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    if (IsImageFile(files[0]))
                    {
                        string imagePath = files[0];
                        Image image = Image.FromFile(imagePath);
                        pictureBox1.Image = image;

                        images.Add(image);
                        index = images.Count - 1;

                        SaveImageToDatabase(image);

                        await Task.Delay(3500);

                        DialogResult result = MessageBox.Show("Pentru ca ai adaugat o pisicuta poti participa la extragerile bonusurilor pisicesti! Vrei?", "Pisicile Salbatice", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            Form16 form = new Form16();
                            form.ShowDialog();
                        }

                        IsImageDropAllowed = false;
                    }
                }
            }
        }

        private void UserControl1_DragEnter(object sender, DragEventArgs e)
        {
            if (IsImageDropAllowed)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    if (IsImageFile(files[0]))
                    {
                        e.Effect = DragDropEffects.Copy;
                        return;
                    }
                }
            }

            e.Effect = DragDropEffects.None;
        }

        private bool IsImageFile(string filePath)
        {
            string extension = System.IO.Path.GetExtension(filePath).ToLower();
            return extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif";
        }

        private void SaveImageToDatabase(Image image)
        {
            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                connection.Open();

                using (OleDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Images ([Image]) VALUES (?)";
                    command.Parameters.AddWithValue("@Image", ImageToByteArray(image));

                    command.ExecuteNonQuery();
                }
            }
        }
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                return Image.FromStream(stream);
            }
        }

        private void LoadImagesFromDatabase()
        {
            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                connection.Open();

                using (OleDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Image] FROM Images";

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            byte[] imageData = (byte[])reader["Image"];
                            Image image = ByteArrayToImage(imageData);
                            images.Add(image);
                        }
                    }
                }
            }

            if (images.Count > 0)
            {
                index = 0;
                pictureBox1.Image = images[index];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (images.Count > 0)
            {
                index++;
                if (index >= images.Count)
                {
                    index = 0;
                }
                pictureBox1.Image = images[index];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (images.Count > 0)
            {
                index--;
                if (index < 0)
                {
                    index = images.Count - 1;
                }
                pictureBox1.Image = images[index];
            }
        }
    }
}