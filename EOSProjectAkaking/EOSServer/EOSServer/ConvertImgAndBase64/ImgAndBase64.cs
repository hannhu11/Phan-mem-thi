using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertImgAndBase64
{
    public partial class ImgAndBase64 : Form
    {

        public string URL = "";
        public ImgAndBase64()
        {
            InitializeComponent();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    picBoxSrc.Image = new Bitmap(dlg.FileName);
                    URL = dlg.FileName;
                }
            }
        }

        public Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }

        public string ImageToBase64(string path)
        {


            using (System.Drawing.Image image = System.Drawing.Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }

        private void btnConvertToBase64_Click(object sender, EventArgs e)
        {
            rtbBase64.Text = ImageToBase64(URL);
            txtLengthBase.Text = rtbBase64.Text.Length.ToString();

        }

        private void resizeImg(int newWidth)
        {


            // Tính toán tỷ lệ giữa chiều rộng mới và chiều rộng ban đầu
            float ratio = (float)newWidth / picBoxSrc.Image.Width;

            // Tính toán chiều cao mới dựa trên tỷ lệ
            int newHeight = (int)(picBoxSrc.Image.Height * ratio);

            // Tạo hình ảnh mới với kích thước mới
            Image resizedImage = new Bitmap(newWidth, newHeight);

            // Sử dụng Graphics để resize hình ảnh
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(picBoxSrc.Image, 0, 0, newWidth, newHeight);
            }

            picBoxSrc.Image = resizedImage;
        }


        private void btnToImg_Click(object sender, EventArgs e)
        {
            picBoxDes.Image = Base64ToImage(rtbBase64.Text);
        }
    }
}
