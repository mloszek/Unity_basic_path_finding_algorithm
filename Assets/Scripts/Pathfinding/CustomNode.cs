
public class CustomNode
{
    public int x;
    public int y;
    public bool isWalkable;
	public bool isVisited;
    public CustomNode parent;

    public CustomNode(int x, int y)
    {
        this.x = x;
        this.y = y;
		isVisited = false;
    }

    public override int GetHashCode()
    {
        return x ^ y;
    }

    public bool Equals(CustomNode p)
    {
        if (p == null)
        {
            return false;
        }

        return (x == p.x) && (y == p.y);
    }
}
