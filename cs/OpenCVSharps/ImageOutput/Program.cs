using OpenCvSharp;

namespace ImageOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var winname = "original";
            Console.WriteLine("OpenCV!!");

            Mat src = Cv2.ImRead("deathstar2.jpg", ImreadModes.ReducedColor2);

            Cv2.NamedWindow(winname, WindowFlags.KeepRatio);
            Cv2.SetWindowProperty(winname, WindowPropertyFlags.AutoSize, 1);
            Cv2.ImShow(winname, src);
            Cv2.WaitKey(0);
            Cv2.DestroyWindow(winname);
        }
    }
}
