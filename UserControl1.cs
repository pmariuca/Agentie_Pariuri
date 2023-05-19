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
        public UserControl1()
        {
            InitializeComponent();
            DragEnter += UserControl1_DragEnter;
            DragDrop += UserControl1_DragDrop;

            pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            Controls.Add(pictureBox);

            images = new List<Image>();
            index = -1;
        }

        private void UserControl1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (IsImageFile(files[0]))
                {
                    string imagePath = files[0];
                    Image image = Image.FromFile(imagePath);
                    pictureBox.Image = image;
                    pictureBox.Size = image.Size;

                    images.Add(image);
                    index = images.Count - 1;

                }
            }
        }

        private void UserControl1_DragEnter(object sender, DragEventArgs e)
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

            e.Effect = DragDropEffects.None;
        }

        private bool IsImageFile(string filePath)
        {
            string extension = System.IO.Path.GetExtension(filePath).ToLower();
            return extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (images.Count > 0)
            {
                if (index < images.Count - 1)
                {
                    index++;
                    pictureBox.Image = images[index];
                    pictureBox.Size = images[index].Size;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index--;
                pictureBox.Image = images[index];
                pictureBox.Size = images[index].Size;
            }
        }
    }
}
