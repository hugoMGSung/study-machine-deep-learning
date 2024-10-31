using OpenCvSharp;

namespace BasicCvType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OpenCvSharp Datatype!!");

            // 벡터구조체 사용
            Console.WriteLine("01. 벡터구조체 사용");
            Vec4d vector1 = new Vec4d(1.0, 2.0, 3.0, 4.0);
            Vec4d vector2 = new Vec4d(1.0, 2.0, 3.0, 4.0);

            Console.WriteLine(vector1.Item0); // Item0 ~ Item3까지
            Console.WriteLine(vector1[1]); // [] 인덱스
            Console.WriteLine(vector1.Equals(vector2));

            // 포인트 구조체
            Console.WriteLine("02. 포인트 구조체");
            Vec3d Vector = new Vec3d(1.0, 2.0, 3.0);
            Point3d Pt1 = new Vec3d(1.0, 2.0, 3.0);
            Point3d Pt2 = Vector;

            Console.WriteLine(Pt1);
            Console.WriteLine(Pt2);
            Console.WriteLine(Pt1.X);

            // 포인터 구조체 벡터연산
            Console.WriteLine("03. 포인트 구조체 벡터연산");
            Point Pt3 = new Point(1, 2);
            Point Pt4 = new Point(3, 2);

            Console.WriteLine(Pt3.DistanceTo(Pt4));
            Console.WriteLine(Pt3.DotProduct(Pt4));
            Console.WriteLine(Pt3.CrossProduct(Pt4));

            Console.WriteLine(Pt3 + Pt4);
            // ...

            // 스칼라 구조체 - 4개의 요소를 갖는 제네릭 구조체
            Console.WriteLine("04. 스칼라 구조체");
            Scalar s1 = new Scalar(255, 127);
            Console.WriteLine(s1);
            Scalar s2 = Scalar.Red; // BGRA 순으로 저장. OpenCV에서는 RGBA 보다 많이 사용됨. 근데 왜? 128??
            Console.WriteLine(s2);
            Scalar s3 = Scalar.All(100);
            Console.WriteLine(s3);

            // 사이즈 구조체
            // OpenCvSharp4.runtime.win 모듈도 포함되어야 함!!
            Console.WriteLine("05. 사이즈 구조체");
            Size size = new Size(640, 480);
            Mat img = new Mat(size, MatType.CV_8UC3);
            Mat img2 = new Mat(img.Size(), MatType.CV_8UC3);

            Console.WriteLine($"{size.Width}, {size.Height}");
            Console.WriteLine($"{img.Size()}");
            Console.WriteLine($"{img.Size().Width}, {img.Size().Height}");
            Console.WriteLine($"{img2.Width}, {img2.Height}");

            // 범위 구조체
            Console.WriteLine("06. 범위 구조체");
            OpenCvSharp.Range range = new OpenCvSharp.Range(0, 100);
            Console.WriteLine($"{range.Start} ~ {range.End}");

            // 직사각형 구조체
            Console.WriteLine("07. 직사각형 구조체");
            Rect rect1 = new Rect(new Point(0,0), new Size(640,480));
            Rect rect2 = new Rect(100, 100, 640, 640);

            Console.WriteLine(rect1);
            Console.WriteLine(rect2);

            // 회전직사각형 구조체
            Console.WriteLine("08. 회전직사각형 구조체");
            // (100, 100) 위치에 (100x100) 크기의 정사각형을 45도 기울여서 만들어라
            RotatedRect rotatedRect = new RotatedRect(new Point2f(100f, 100f), new Size2f(100, 100), 45f);

            Console.WriteLine(rotatedRect.BoundingRect());
            Console.WriteLine(rotatedRect.Points().Length);
            Console.WriteLine(rotatedRect.Points()[0]);





        }
    }
}
