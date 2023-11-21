using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab3_tasks2_WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

        }
       
        private Image MirrorImage(Image originalImage)
        {
            originalImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
            return originalImage;
        }
        private void button1_Click_1(object sender, EventArgs e)
         {
             OpenFileDialog ofd = new OpenFileDialog();
             ofd.Filter = "Image Files (*.bmp, *.jpg, *.png, *.gif, *.tiff)|*.bmp;*.jpg;*.png;*.gif;*.tiff|All Files(*.*)|*.*";
             if (ofd.ShowDialog() == DialogResult.OK)
             {
                try{

                 Image originalImage = new Bitmap(ofd.FileName);
                 pictureBox1.Image = new Bitmap(ofd.FileName);

                 Image mirroredImage = MirrorImage(originalImage);
                 pictureBox2.Image = mirroredImage;

                 string mirroredFilePath = Path.GetDirectoryName(ofd.FileName) + "\\" + Path.GetFileNameWithoutExtension(ofd.FileName) + "_mirrored.gif";
                 mirroredImage.Save(mirroredFilePath, System.Drawing.Imaging.ImageFormat.Gif);

                 MessageBox.Show("Image mirrored successfully!");
                }
                catch
                {
                 MessageBox.Show("The selected file cannot be opened!!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
             }
         }

         
    }
}
        

