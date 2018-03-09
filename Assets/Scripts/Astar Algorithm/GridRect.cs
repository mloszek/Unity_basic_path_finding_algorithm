public class GridRect
{
    public int minX;
    public int minY;
    public int maxX;
    public int maxY;

    public GridRect()
    {
        minX = 0;
        minY = 0;
        maxX = 0;
        maxY = 0;
    }

    public GridRect(GridRect b)
    {
        minX = b.minX;
        minY = b.minY;
        maxX = b.maxX;
        maxY = b.maxY;
    }
}