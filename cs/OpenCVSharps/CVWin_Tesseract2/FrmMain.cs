using OpenCvSharp;
using Tesseract;
using OpenCvSharp.Extensions;
// 네임스페이스 일차 정리!

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
            // 이미지 파일을 불러와서 Mat 객체로 저장 (Unchanged 옵션으로 읽어들임)
            // 이때 Unchanged 모드는 이미지의 채널과 포맷을 변경하지 않고 그대로 읽어옴
            Mat src = Cv2.ImRead("../../../../../../images/carnum_plate.png", ImreadModes.Unchanged);

            // 마지막에 윈도우 화면에 뿌리기!!
            // Mat 객체를 Bitmap으로 변환하여 PictureBox에 표시
            // OpenCvSharp.Extensions.BitmapConverter.ToBitmap 메서드를 사용하여 Mat을 Bitmap으로 변환
            this.PicResult.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(src);
            // PictureBox 크기를 이미지에 맞게 확장하여 표시
            this.PicResult.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            // PictureBox에서 이미지를 가져와 Bitmap으로 변환
            Bitmap img = new Bitmap(PicResult.Image);
            // Bitmap을 Mat으로 변환 (OpenCV 처리용)
            Mat mat = BitmapConverter.ToMat(img);

            // 이미지를 그레이스케일로 변환
            Mat gray = new Mat();
            Cv2.CvtColor(mat, gray, ColorConversionCodes.BGR2GRAY); // 컬러 이미지를 흑백으로 변환

            //// 이진화 처리 (흑백)
            //Mat thresholded = new Mat();
            //Cv2.Threshold(gray, thresholded, 150, 255, ThresholdTypes.Binary);

            //// 결과 이미지를 다시 Bitmap으로 변환
            //Bitmap processedImage = BitmapConverter.ToBitmap(thresholded);

            // 텍스트가 있을 가능성이 있는 영역만 찾기 위해 이진화 처리된 이미지를 사용
            Mat thresholded = new Mat();
            Cv2.Threshold(gray, thresholded, 150, 255, ThresholdTypes.Binary); // 흑백 이진화

            // 윤곽선 감지 (이미지에서 텍스트 영역을 추출)
            Mat hierachy = new Mat();
            var contours = new OpenCvSharp.Mat[] { }; // 윤곽선 배열 초기화
            Cv2.FindContours(thresholded, out contours, hierachy, RetrievalModes.List, ContourApproximationModes.ApproxSimple);



            // 각 윤곽선을 검사하여 텍스트 영역으로 추정되는 영역을 찾음
            foreach (var contour in contours)
            {
                // 윤곽선에 대한 경계 상자(bounding box) 계산
                OpenCvSharp.Rect boundingBox = Cv2.BoundingRect(contour);

                // 텍스트 영역의 최소 크기를 설정 (너비 50, 높이 20 이상인 영역만 추출)
                if (boundingBox.Width > 50 && boundingBox.Height > 20)  // 텍스트 영역 크기 조건을 설정
                {
                    // 텍스트 영역(ROI: Region of Interest)만 추출
                    Mat roi = gray[boundingBox];  // 지정된 영역만 잘라냄

                    // 추출된 텍스트 영역을 PictureBox에 표시
                    this.PicResult.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(roi);
                    this.PicResult.SizeMode = PictureBoxSizeMode.StretchImage;

                    // 텍스트 인식을 위해 추출된 영역을 메모리 스트림에 저장
                    using (var memoryStream = new MemoryStream())
                    {
                        // Mat을 Bitmap으로 변환하고 PNG 형식으로 메모리 스트림에 저장
                        Bitmap roiImage = BitmapConverter.ToBitmap(roi); // Mat을 Bitmap으로 변환
                        roiImage.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

                        // 메모리에서 이미지를 로드하여 Tesseract로 OCR 처리
                        using (var pix = Pix.LoadFromMemory(memoryStream.ToArray()))
                        {
                            // Tesseract OCR 엔진 초기화 (한글과 영어 인식 설정)
                            var ocr = new TesseractEngine("./tessdata", "kor+eng", EngineMode.Default);
                            // OCR 처리 후 텍스트 추출
                            var result = ocr.Process(pix);
                            // 인식된 텍스트를 메시지 박스로 출력
                            MessageBox.Show(result.GetText());
                        }

                        break; // 한번만 실행 후 종료!
                    }
                }
            }

            //// 마지막에 윈도우 화면에 뿌리기!!
            //this.PicResult.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(thresholded);
            //this.PicResult.SizeMode = PictureBoxSizeMode.StretchImage;

            //// Bitmap을 MemoryStream으로 변환
            //using (var memoryStream = new MemoryStream())
            //{
            //    img.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

            //    // MemoryStream에서 Pix로 변환
            //    using (var pix = Pix.LoadFromMemory(memoryStream.ToArray()))
            //    {
            //        var ocr = new TesseractEngine("./tessdata", "kor+eng", EngineMode.Default);

            //        // OCR 처리
            //        var result = ocr.Process(pix);

            //        // OCR 결과 출력
            //        MessageBox.Show(result.GetText());
            //    }
            //}

        }

    }
}
