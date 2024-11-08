using OpenCvSharp;

namespace MovieOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var movieName = "../../../../../../images/deathstar2.mp4";

            Console.WriteLine("OpenCV Movie!!");

            VideoCapture capture = new VideoCapture(movieName);
            Mat frame = new Mat();

            // FPS 추가
            

            while (true)
            {
                if (capture.PosFrames == capture.FrameCount) capture.Open(movieName);

                capture.Read(frame);
                Cv2.ImShow("VideoFrame", frame);

                if (Cv2.WaitKey(33) == 'q') break;
            }

            capture.Release();
            Cv2.DestroyAllWindows();
        }
    }
}
