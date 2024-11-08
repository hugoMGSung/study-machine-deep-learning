using OpenCvSharp;

namespace CVCnsMovSave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var movieFile = "../../../../../../images/deathstar2.mp4";
            VideoCapture capture = new VideoCapture(movieFile);
            Mat frame = new Mat(new Size(capture.FrameWidth, capture.FrameHeight), MatType.CV_8UC3);
            VideoWriter videoWriter = new VideoWriter();
            bool isWrite = false;

            while (true)
            {
                if (capture.PosFrames == capture.FrameCount)
                    capture.Open(movieFile);

                capture.Read(frame);
                Cv2.ImShow("VideoCapture", frame);

                int key = Cv2.WaitKey(33);
                if (key == 'b')  // 4 (Alt + D) 동작안됨
                {
                    videoWriter.Open("../../../../../../images/video.avi", FourCC.XVID, 30, frame.Size(), true);
                    Cv2.SetWindowTitle("VideoCapture", "Capture Start!!");
                    isWrite = true;

                }
                else if (key == 's')  // 24 (Alt + X) 동작안됨
                {
                    videoWriter.Release();
                    Cv2.SetWindowTitle("VideoCapture", "Capture Stoped!!");

                    isWrite = false;
                }
                else if (key == 'q')
                    break;

                if (isWrite == true)
                    videoWriter.Write(frame);
            }

            videoWriter.Release();
            capture.Release();
            Cv2.DestroyAllWindows();
        }
    }
}
