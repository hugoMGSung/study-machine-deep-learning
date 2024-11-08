using OpenCvSharp;

namespace CVCns_708
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OpenCV sysnet.pe.kr!");

            VideoCapture capture = new VideoCapture("../../../../../../images/deathstar2.mp4");
            //capture.Set(VideoCaptureProperties.FrameWidth, 1280);
            //capture.Set(VideoCaptureProperties.FrameHeight, 720);

            int sleepTime = (int)Math.Round(1000 / capture.Fps);

            using (Window window = new Window("capture"))
            using (Mat frame = new Mat()) // Frame image buffer
            {
                // When the movie playback reaches end, Mat.data becomes NULL.
                while (true)
                {
                    capture.Read(frame); // same as cvQueryFrame
                    Cv2.PutText(frame, capture.Get(VideoCaptureProperties.Fps).ToString(),
                                new Point(40, 50), HersheyFonts.HersheySimplex, 1.0, new Scalar(255, 255, 255), 2);
                    if (frame.Empty())
                        break;

                    window.ShowImage(frame);
                    if (Cv2.WaitKey(sleepTime) == 'q') break;
                }
            }
        }
    }
}
