using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class MainForm : Form
    {
        private Bitmap loadedImage;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Bitmap files (*.bmp)|*.bmp";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                loadedImage = new Bitmap(dialog.FileName);
                pictureBox.Image = loadedImage;
            }
        }
    }
}