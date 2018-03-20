
public class CustomNode : INode
{
    private int m_x;
    private int m_y;
    private bool m_isWalkable;
    private bool m_isVisited;
    private CustomNode m_parent;

    public CustomNode(int x, int y)
    {
        m_x = x;
        m_y = y;
        m_isVisited = false;
    }

    public int x
    {
        get { return m_x; }
        set { m_x = value; }
    }

    public int y
    {
        get { return m_y; }
        set { m_y = value; }
    }

    public bool isWalkable
    {
        get { return m_isWalkable; }
        set { m_isWalkable = value; }
    }

    public bool isVisited
    {
        get { return m_isVisited; }
        set { m_isVisited = value; }
    }

    public CustomNode parent
    {
        get { return m_parent; }
        set { m_parent = value; }
    }

    public override int GetHashCode()
    {
        return m_x ^ m_y;
    }

    public bool Equals(CustomNode p)
    {
        if (p == null)
        {
            return false;
        }

        return (m_x == p.m_x) && (m_y == p.m_y);
    }
}
