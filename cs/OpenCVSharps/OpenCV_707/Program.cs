using OpenCvSharp;

namespace OpenCV_707
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OpenCV sysnet.pe.kr!");

            Mat src = new Mat("starwars2019.webp", ImreadModes.ReducedGrayscale2);
            Mat dst = new Mat();

            Cv2.Canny(src, dst, 50, 200);
            using (new Window("src img", src))
            using (new Window("dst img", dst))
            {
                Cv2.WaitKey();
            }
        }
    }
}
