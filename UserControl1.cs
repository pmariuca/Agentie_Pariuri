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
        public bool IsImageDropAllowed { get; private set; }
        public UserControl1()
        {
            InitializeComponent();
            DragEnter += UserControl1_DragEnter;
            DragDrop += UserControl1_DragDrop;

            images = new List<Image>();
            index = -1;
            IsImageDropAllowed = false;
        }

        public void SetImageDropAllowed(bool allowed)
        {
            IsImageDropAllowed = allowed;
        }

        private void UserControl1_DragDrop(object sender, DragEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (images.Count > 0)
            {
                if (index < images.Count - 1)
                {
                    index++;
                    pictureBox1.Image = images[index];
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index--;
                pictureBox1.Image = images[index];
            }
        }
    }
}
