using OpenCvSharp;

namespace CVCns_708
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OpenCV sysnet.pe.kr!");

            VideoCapture capture = new VideoCapture("../../../../../../images/deathstar2.mp4");

            int sleepTime = (int)Math.Round(1000 / capture.Fps);

            using (Window window = new Window("capture"))
            using (Mat frame = new Mat()) // Frame image buffer
            {
                // When the movie playback reaches end, Mat.data becomes NULL.
                while (true)
                {
                    capture.Read(frame); // same as cvQueryFrame
                    if (frame.Empty())
                        break;

                    window.ShowImage(frame);
                    Cv2.WaitKey(sleepTime);
                }
            }
        }
    }
}
