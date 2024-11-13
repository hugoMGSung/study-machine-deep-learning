using OpenCvSharp;
using System.Security.Cryptography;

namespace CVWin_0501
{
    public partial class FrmMain : Form
    {
        Mat src = null;
        int clickCnt = 1;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            src = Cv2.ImRead("../../../../../../images/MnMs.png");
            Mat dst = new Mat(src.Size(), MatType.CV_8UC1);
            Cv2.CvtColor(src, dst, ColorConversionCodes.BGR2GRAY);

            this.pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(dst);
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            clickCnt++;

            if (clickCnt % 3 == 0)
            {
                Mat snd = new Mat();
                Cv2.CvtColor(src, snd, ColorConversionCodes.BGR2HSV);

                this.pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(snd);
            }
            else if (clickCnt % 3 == 1)
            {
                Mat snd = new Mat();
                Cv2.CvtColor(src, snd, ColorConversionCodes.BGR2GRAY);

                this.pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(snd);
            }
            else
            {
                Mat hsv = new Mat(src.Size(), MatType.CV_8UC3);
                Mat dst = new Mat(src.Size(), MatType.CV_8UC3);

                Cv2.CvtColor(src, hsv, ColorConversionCodes.BGR2HSV);
                Mat[] HSV = Cv2.Split(hsv);
                Mat H_blue = new Mat(src.Size(), MatType.CV_8UC1);
                Cv2.InRange(HSV[0], new Scalar(70, 0, 0), new Scalar(130, 255, 255), H_blue);

                Cv2.BitwiseAnd(hsv, hsv, dst, H_blue);
                Cv2.CvtColor(dst, dst, ColorConversionCodes.HSV2BGR);

                this.pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(dst);
            }

        }
    }
}
