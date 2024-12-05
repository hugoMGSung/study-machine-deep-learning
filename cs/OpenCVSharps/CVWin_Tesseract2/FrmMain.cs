using OpenCvSharp;
using Tesseract;
using OpenCvSharp.Extensions;
// ���ӽ����̽� ���� ����!

namespace CVWin_Tesseract2
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // �̹��� ������ �ҷ��ͼ� Mat ��ü�� ���� (Unchanged �ɼ����� �о����)
            // �̶� Unchanged ���� �̹����� ä�ΰ� ������ �������� �ʰ� �״�� �о��
            Mat src = Cv2.ImRead("../../../../../../images/carnum_plate.png", ImreadModes.Unchanged);

            // �������� ������ ȭ�鿡 �Ѹ���!!
            // Mat ��ü�� Bitmap���� ��ȯ�Ͽ� PictureBox�� ǥ��
            // OpenCvSharp.Extensions.BitmapConverter.ToBitmap �޼��带 ����Ͽ� Mat�� Bitmap���� ��ȯ
            this.PicResult.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(src);
            // PictureBox ũ�⸦ �̹����� �°� Ȯ���Ͽ� ǥ��
            this.PicResult.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            // PictureBox���� �̹����� ������ Bitmap���� ��ȯ
            Bitmap img = new Bitmap(PicResult.Image);
            // Bitmap�� Mat���� ��ȯ (OpenCV ó����)
            Mat mat = BitmapConverter.ToMat(img);

            // �̹����� �׷��̽����Ϸ� ��ȯ
            Mat gray = new Mat();
            Cv2.CvtColor(mat, gray, ColorConversionCodes.BGR2GRAY); // �÷� �̹����� ������� ��ȯ

            //// ����ȭ ó�� (���)
            //Mat thresholded = new Mat();
            //Cv2.Threshold(gray, thresholded, 150, 255, ThresholdTypes.Binary);

            //// ��� �̹����� �ٽ� Bitmap���� ��ȯ
            //Bitmap processedImage = BitmapConverter.ToBitmap(thresholded);

            // �ؽ�Ʈ�� ���� ���ɼ��� �ִ� ������ ã�� ���� ����ȭ ó���� �̹����� ���
            Mat thresholded = new Mat();
            Cv2.Threshold(gray, thresholded, 150, 255, ThresholdTypes.Binary); // ��� ����ȭ

            // ������ ���� (�̹������� �ؽ�Ʈ ������ ����)
            Mat hierachy = new Mat();
            var contours = new OpenCvSharp.Mat[] { }; // ������ �迭 �ʱ�ȭ
            Cv2.FindContours(thresholded, out contours, hierachy, RetrievalModes.List, ContourApproximationModes.ApproxSimple);



            // �� �������� �˻��Ͽ� �ؽ�Ʈ �������� �����Ǵ� ������ ã��
            foreach (var contour in contours)
            {
                // �������� ���� ��� ����(bounding box) ���
                OpenCvSharp.Rect boundingBox = Cv2.BoundingRect(contour);

                // �ؽ�Ʈ ������ �ּ� ũ�⸦ ���� (�ʺ� 50, ���� 20 �̻��� ������ ����)
                if (boundingBox.Width > 50 && boundingBox.Height > 20)  // �ؽ�Ʈ ���� ũ�� ������ ����
                {
                    // �ؽ�Ʈ ����(ROI: Region of Interest)�� ����
                    Mat roi = gray[boundingBox];  // ������ ������ �߶�

                    // ����� �ؽ�Ʈ ������ PictureBox�� ǥ��
                    this.PicResult.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(roi);
                    this.PicResult.SizeMode = PictureBoxSizeMode.StretchImage;

                    // �ؽ�Ʈ �ν��� ���� ����� ������ �޸� ��Ʈ���� ����
                    using (var memoryStream = new MemoryStream())
                    {
                        // Mat�� Bitmap���� ��ȯ�ϰ� PNG �������� �޸� ��Ʈ���� ����
                        Bitmap roiImage = BitmapConverter.ToBitmap(roi); // Mat�� Bitmap���� ��ȯ
                        roiImage.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

                        // �޸𸮿��� �̹����� �ε��Ͽ� Tesseract�� OCR ó��
                        using (var pix = Pix.LoadFromMemory(memoryStream.ToArray()))
                        {
                            // Tesseract OCR ���� �ʱ�ȭ (�ѱ۰� ���� �ν� ����)
                            var ocr = new TesseractEngine("./tessdata", "kor+eng", EngineMode.Default);
                            // OCR ó�� �� �ؽ�Ʈ ����
                            var result = ocr.Process(pix);
                            // �νĵ� �ؽ�Ʈ�� �޽��� �ڽ��� ���
                            MessageBox.Show(result.GetText());
                        }

                        break; // �ѹ��� ���� �� ����!
                    }
                }
            }

            //// �������� ������ ȭ�鿡 �Ѹ���!!
            //this.PicResult.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(thresholded);
            //this.PicResult.SizeMode = PictureBoxSizeMode.StretchImage;

            //// Bitmap�� MemoryStream���� ��ȯ
            //using (var memoryStream = new MemoryStream())
            //{
            //    img.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

            //    // MemoryStream���� Pix�� ��ȯ
            //    using (var pix = Pix.LoadFromMemory(memoryStream.ToArray()))
            //    {
            //        var ocr = new TesseractEngine("./tessdata", "kor+eng", EngineMode.Default);

            //        // OCR ó��
            //        var result = ocr.Process(pix);

            //        // OCR ��� ���
            //        MessageBox.Show(result.GetText());
            //    }
            //}

        }

    }
}
