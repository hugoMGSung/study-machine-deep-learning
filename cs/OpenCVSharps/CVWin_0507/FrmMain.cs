using OpenCvSharp;

namespace CVWin_0507
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Mat src = Cv2.ImRead("../../../../../../images/swan-in-the-dark.jpg");
            Mat gray = new Mat(src.Size(), MatType.CV_8UC1);
            Mat binary = new Mat(src.Size(), MatType.CV_8UC1);

            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            // ����ȭ
            //Cv2.Threshold(src, binary, 127, 255, ThresholdTypes.Binary); // Otsu, Binary, BinaryInv
            //Cv2.Threshold(gray, binary, 127, 255, ThresholdTypes.Binary); // Otsu, Binary, BinaryInv
            // ������ ����ȭ
            Cv2.AdaptiveThreshold(gray, binary, 255, AdaptiveThresholdTypes.GaussianC, ThresholdTypes.Binary, 25, 3);

            Mat dst = new Mat();

            Cv2.GaussianBlur(src, dst, new OpenCvSharp.Size(9, 9), 3, 3, BorderTypes.Isolated);
            
            // ����ȭ
            // this.pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(binary);
            // ����þ� �帲
            this.pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(dst);
        }
    }
}
