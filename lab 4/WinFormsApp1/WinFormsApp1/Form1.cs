namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }
        private Bitmap loadedImage;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Bitmap (*.bmp)|*.bmp";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                loadedImage = new Bitmap(dialog.FileName);
                pictureBox1.Image = loadedImage;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (loadedImage == null) return;

            if (radioButton1.Checked)        // 90°
                loadedImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            else if (radioButton2.Checked)   // 180°
                loadedImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            else if (radioButton3.Checked)   // 270°
                loadedImage.RotateFlip(RotateFlipType.Rotate270FlipNone);

            pictureBox1.Image = loadedImage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (loadedImage == null) return;

            loadedImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pictureBox1.Image = loadedImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (loadedImage == null) return;

            for (int y = 0; y < loadedImage.Height; y++)
            {
                for (int x = 0; x < loadedImage.Width; x++)
                {
                    Color c = loadedImage.GetPixel(x, y);
                    Color inv = Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);
                    loadedImage.SetPixel(x, y, inv);
                }
            }

            pictureBox1.Image = loadedImage;
        }
    }
}
