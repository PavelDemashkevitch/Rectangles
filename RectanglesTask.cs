using System;

namespace Rectangles
{
    public static class RectanglesTask
    {
        static int Ax1;
        static int Ax2;
        static int Ay1;
        static int Ay2;

        static int Bx1;
        static int Bx2;
        static int By1;
        static int By2;

        // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {
            // так можно обратиться к координатам левого верхнего угла первого прямоугольника: r1.Left, r1.Top
            SetCoordinates(r1, r2);

            if (Ax2 >= Bx1 && Bx2 >= Ax1 && Ay2 <= By1 && By2 <= Ay1) return true;
            else return false;
        }

        // Площадь пересечения прямоугольников
        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        {
            SetCoordinates(r1, r2);

            if (Ax2 >= Bx1 && Bx2 >= Ax1 && Ay2 <= By1 && By2 <= Ay1)
            {
                int a = Math.Min(Ay1, By1) - Math.Max(Ay2, By2);

                int b = Math.Min(Ax2, Bx2) - Math.Max(Bx1, Ax1);

                return Math.Abs(a * b);
            }
            else return 0;
           
        }

        // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
        // Иначе вернуть -1
        // Если прямоугольники совпадают, можно вернуть номер любого из них.
        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
        {
            SetCoordinates(r1, r2);

            if (Ax1 >= Bx1 && Ax2 <= Bx2 && Ay1 <= By1 && Ay2 >= By2)
            {
                return 0;
            }
            else if (Ax1 <= Bx1 && Ax2 >= Bx2 && Ay1 >= By1 && Ay2 <= By2)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        static void SetCoordinates(Rectangle r1, Rectangle r2)
        {
            Ax1 = r1.Left;
            Ax2 = r1.Width + r1.Left;
            Ay2 = r1.Top;
            Ay1 = r1.Top + r1.Height;

            Bx1 = r2.Left;
            Bx2 = r2.Width + r2.Left;
            By2 = r2.Top;
            By1 = r2.Top + r2.Height;
        }
    }
}