namespace paint_cg
{
    public class PointData
    {
        public string Name { get; set; } = "";
        public int X { get; set; }
        public int Y { get; set; }

        public PointData()
        {
        }

        public PointData(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public Point ToPoint()
        {
            return new Point(X, Y);
        }
    }
}