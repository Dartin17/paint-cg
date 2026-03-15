using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paint_cg
{
    public static class Primitives
    {
        public static void WritePixel(Bitmap bitmap, int x, int y, Color color)
        {
            if (x >= 0 && y >= 0 && x < bitmap.Width && y < bitmap.Height)
            {
                bitmap.SetPixel(x, y, color);
            }
        }

        //========== Equações para retas ===========
        public static void LineEquation(Bitmap bitmap, Point p1, Point p2, Color color)
        {
            int x1 = p1.X;
            int y1 = p1.Y;
            int x2 = p2.X;
            int y2 = p2.Y;

            int dx = x2 - x1;
            int dy = y2 - y1;

            if (Math.Abs(dx) >= Math.Abs(dy))
            {
                if (x1 > x2)
                {
                    (x1, x2) = (x2, x1);
                    (y1, y2) = (y2, y1);
                }

                double m = (double)(y2 - y1) / (x2 - x1);

                double y = y1;

                for (int x = x1; x <= x2; x++)
                {
                    WritePixel(bitmap, x, (int)Math.Round(y), color);
                    y += m;
                }
            }
            else
            {
                if (y1 > y2)
                {
                    (x1, x2) = (x2, x1);
                    (y1, y2) = (y2, y1);
                }

                double m = (double)(x2 - x1) / (y2 - y1);

                double x = x1;

                for (int y = y1; y <= y2; y++)
                {
                    WritePixel(bitmap, (int)Math.Round(x), y, color);
                    x += m;
                }
            }
        }

        public static void LineDDA(Bitmap canvas, Point p1, Point p2, Color color)
        {
            int x1 = p1.X;
            int y1 = p1.Y;
            int x2 = p2.X;
            int y2 = p2.Y;

            int dx = x2 - x1;
            int dy = y2 - y1;

            int passos = Math.Abs(dx);

            if (Math.Abs(dy) > passos)
            {
                passos = Math.Abs(dy);
            }

            float incrementoX = 0;
            float incrementoY = 0;

            if (passos != 0)
            {
                incrementoX = dx / (float)passos;
                incrementoY = dy / (float)passos;
            }

            float x = x1;
            float y = y1;

            for (int i = 0; i <= passos; i++)
            {
                int px = (int)Math.Round(x);
                int py = (int)Math.Round(y);

                WritePixel(canvas, px, py, color);

                x = x + incrementoX;
                y = y + incrementoY;
            }
        }


        public static void LineMidpoint(Bitmap canvas, Point p1, Point p2, Color color)
        {
            int x1 = p1.X;
            int y1 = p1.Y;
            int x2 = p2.X;
            int y2 = p2.Y;

            int dx = x2 - x1;
            int dy = y2 - y1;

            int passoX = 1;
            int passoY = 1;

            if (dx < 0)
            {
                passoX = -1;
                dx = dx * -1;
            }

            if (dy < 0)
            {
                passoY = -1;
                dy = dy * -1;
            }

            int x = x1;
            int y = y1;

            if (dx >= dy)
            {
                int d = 2 * dy - dx;
                int incE = 2 * dy;
                int incNE = 2 * (dy - dx);

                for (int i = 0; i <= dx; i++)
                {
                    WritePixel(canvas, x, y, color);

                    if (d < 0)
                    {
                        d = d + incE;
                    }
                    else
                    {
                        d = d + incNE;
                        y = y + passoY;
                    }

                    x = x + passoX;
                }
            }
            else
            {
                int d = 2 * dx - dy;
                int incE = 2 * dx;
                int incNE = 2 * (dx - dy);

                for (int i = 0; i <= dy; i++)
                {
                    WritePixel(canvas, x, y, color);

                    if (d < 0)
                    {
                        d = d + incE;
                    }
                    else
                    {
                        d = d + incNE;
                        x = x + passoX;
                    }

                    y = y + passoY;
                }
            }
        }

        //========== Equações da circunferência ===========
        public static void CircleEquation(Bitmap canvas, Point centro, Point pf, Color color)
        {
            int xc = centro.X;
            int yc = centro.Y;

            int dx = pf.X - xc;
            int dy = pf.Y - yc;

            int raio = (int)Math.Sqrt(dx * dx + dy * dy);

            double limite = raio / Math.Sqrt(2.0);

            for (int x = 0; x <= (int)limite; x++)
            {
                double valor = raio * raio - x * x;
                int y = (int)Math.Round(Math.Sqrt(valor));

                PlotCirclePoints(canvas, xc, yc, x, y, color);
            }
        }
        private static void PlotCirclePoints(Bitmap canvas, int xc, int yc, int x, int y, Color color)
        {
            SetPixelSafe(canvas, xc + x, yc + y, color);
            SetPixelSafe(canvas, xc + y, yc + x, color);
            SetPixelSafe(canvas, xc + y, yc - x, color);
            SetPixelSafe(canvas, xc + x, yc - y, color);
            SetPixelSafe(canvas, xc - x, yc - y, color);
            SetPixelSafe(canvas, xc - y, yc - x, color);
            SetPixelSafe(canvas, xc - y, yc + x, color);
            SetPixelSafe(canvas, xc - x, yc + y, color);
        }

        private static void SetPixelSafe(Bitmap canvas, int x, int y, Color color)
        {
            if (x >= 0 && x < canvas.Width && y >= 0 && y < canvas.Height)
            {
                canvas.SetPixel(x, y, color);
            }
        }

        public static void CircleTrigonometric(Bitmap canvas, Point centro, Point pf, Color color)
        {
            int xc = centro.X;
            int yc = centro.Y;

            int dx = pf.X - xc;
            int dy = pf.Y - yc;

            int raio = (int)Math.Sqrt(dx * dx + dy * dy);

            if (raio > 0)
            {
                double passoAngulo = 1.0 / raio;

                for (double angulo = 0; angulo <= 2 * Math.PI; angulo += passoAngulo)
                {
                    int x = xc + (int)Math.Round(raio * Math.Cos(angulo));
                    int y = yc + (int)Math.Round(raio * Math.Sin(angulo));

                    if (x >= 0 && x < canvas.Width && y >= 0 && y < canvas.Height)
                    {
                        canvas.SetPixel(x, y, color);
                    }
                }
            }
            else
            {
                if (xc >= 0 && xc < canvas.Width && yc >= 0 && yc < canvas.Height)
                {
                    canvas.SetPixel(xc, yc, color);
                }
            }
        }

        public static void CircleMidpoint(Bitmap canvas, Point centro, Point pf, Color color)
        {
            int xc = centro.X;
            int yc = centro.Y;

            int deltaX = pf.X - xc;
            int deltaY = pf.Y - yc;

            int raio = (int)Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

            int x = 0;
            int y = raio;
            int decisao = 1 - raio;

            PlotCirclePoints(canvas, xc, yc, x, y, color);

            while (x < y)
            {
                x = x + 1;

                if (decisao < 0)
                {
                    decisao = decisao + (2 * x) + 1;
                }
                else
                {
                    y = y - 1;
                    decisao = decisao + (2 * x) - (2 * y) + 1;
                }

                PlotCirclePoints(canvas, xc, yc, x, y, color);
            }
        }

        //========== Equações da Elipse ===========
        public static void EllipseMidpoint(Bitmap bitmap, Point centro, Point pf, Color color)
        {
            long xc = centro.X;
            long yc = centro.Y;

            long a = Math.Abs(pf.X - xc);
            long b = Math.Abs(pf.Y - yc);

            long a2 = a * a;
            long b2 = b * b;

            long x = 0;
            long y = b;

            double d1 = b2 - (a2 * b) + (a2 / 4.0);
            double dx = 2 * b2 * x;
            double dy = 2 * a2 * y;

            PlotEllipsePoints(bitmap, xc, yc, x, y, color);

            while (dx < dy)
            {
                x = x + 1;
                dx = dx + (2 * b2);

                if (d1 < 0)
                {
                    d1 = d1 + dx + b2;
                }
                else
                {
                    y = y - 1;
                    dy = dy - (2 * a2);
                    d1 = d1 + dx - dy + b2;
                }

                PlotEllipsePoints(bitmap, xc, yc, x, y, color);
            }

            double d2 = (b2 * Math.Pow(x + 0.5, 2)) + (a2 * Math.Pow(y - 1, 2)) - (a2 * b2);

            while (y >= 0)
            {
                y = y - 1;
                dy = dy - (2 * a2);

                if (d2 > 0)
                {
                    d2 = d2 + a2 - dy;
                }
                else
                {
                    x = x + 1;
                    dx = dx + (2 * b2);
                    d2 = d2 + dx - dy + a2;
                }

                PlotEllipsePoints(bitmap, xc, yc, x, y, color);
            }
        }

        private static void PlotEllipsePoints(Bitmap bitmap, long xc, long yc, long x, long y, Color color)
        {
            WritePixel(bitmap, (int)(xc + x), (int)(yc + y), color);
            WritePixel(bitmap, (int)(xc - x), (int)(yc + y), color);
            WritePixel(bitmap, (int)(xc + x), (int)(yc - y), color);
            WritePixel(bitmap, (int)(xc - x), (int)(yc - y), color);
        }
    }
}
