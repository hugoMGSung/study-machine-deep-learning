using OpenCvSharp;

namespace CVCnsCamera
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OpenCV Camera");

            VideoCapture capture = new VideoCapture(0, VideoCaptureAPIs.DSHOW);
            Mat frame = new Mat();
            capture.Set(VideoCaptureProperties.FrameWidth, 1280);
            capture.Set(VideoCaptureProperties.FrameHeight, 720);

            while (true)
            {
                if (capture.IsOpened() == true)
                {
                    capture.Read(frame);
                    Cv2.PutText(frame, capture.Get(VideoCaptureProperties.Fps).ToString(), 
                                new Point(50, 100), HersheyFonts.HersheySimplex, 2.0, new Scalar(255, 255, 255), 3);
                    Cv2.ImShow("WebCam", frame);
                    if (Cv2.WaitKey(33) == 'q') break;
                }
            }

            capture.Release();
            Cv2.DestroyAllWindows();
        }
    }
}
