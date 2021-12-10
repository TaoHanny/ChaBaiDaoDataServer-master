using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ChaBaiDaoDataServer.utils
{
    public class PictureRotateUtil
    {

        private string TAG = "PictureRotateUtil";
        private float angle = 0;
        //private  Image RotateImage(Image image, float angle)
        //{


        //    float dx = image.Width/2f;
        //    float dy = image.Height/2f;

        //    Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
        //    rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        //    Graphics g = Graphics.FromImage(rotatedBmp);
        //    g.TranslateTransform(dx, dy);
        //    g.RotateTransform(angle);
        //    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //    g.SmoothingMode = SmoothingMode.AntiAlias;
        //    g.TranslateTransform(-dx, -dy);
        //    g.DrawImage(image, new PointF(0, 0));
        //    return rotatedBmp;
        //}
        private System.Timers.Timer timer = new System.Timers.Timer(1000);
        private Dictionary<int, PictureBox> pictureBoxs = new Dictionary<int, PictureBox>();
        public void StartRotate(int index ,PictureBox pic1)
        {
            isStart = true;
            pictureBoxs.Add(index, pic1);
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(theout);
            
        }

        public void StopRotate(int index)
        {
            pictureBoxs.Remove(index);
            if (pictureBoxs.Count == 0)
            {
                isStart = false;
                timer.Stop();
            }
        }

        private void theout(object source, System.Timers.ElapsedEventArgs e)
        {
            foreach(PictureBox pictureBox in pictureBoxs.Values)
            {
                ImageElapsed(pictureBox);
            }
                
        }
        private static bool isStart = false;

        private void ImageElapsed(PictureBox pic1)
        {

            if(isStart )
            {
                angle += 0.1f;
                if (angle >= 359) angle = 0;
                RotateImage(pic1, pic1.Image, angle);
            }
        }

        public void RotateImage(PictureBox pb, Image img, float angle)
        {
            if (img == null || pb.Image == null)
                return;
            Image oldImage = pb.Image;

            //pb.Image = RotateImage(img, angle);
            oldImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pb.Image = oldImage;
            //if (oldImage != null)
            //{
            //    oldImage.Dispose();
            //    oldImage = null;
            //}
        }

        private void setImageViewUi(PictureBox imageView, Image img)
        {
            imageView.Image = img;
        }

        private void setImageView(PictureBox imageView, Image img)
        {
            if (imageView.InvokeRequired)
            {
                while (!imageView.IsHandleCreated)
                {
                    if (imageView.Disposing || imageView.IsDisposed)
                    {
                        return;
                    }

                }
                SetImageCallback d = new SetImageCallback(setImageViewUi);
                imageView.Invoke(d, new object[] { imageView, img });
            }
            else
            {
                imageView.Image = img;
            }
        }
        delegate void SetImageCallback(PictureBox imageView, Image img);

    }
}
