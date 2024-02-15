public class Point
{
    public int Row { get; set; }
    public int Column { get; set; }

    public Point() { }

    public Point(int i_Row, int i_Column)
    {
        Row = i_Row;
        Column = i_Column;
    }

    public static Point operator ++(Point i_Point)
    {
        return new Point(i_Point.Row + 1, i_Point.Column + 1);
    }

    public static Point operator --(Point i_Point)
    {
        return new Point(i_Point.Row - 1, i_Point.Column - 1);
    }
}