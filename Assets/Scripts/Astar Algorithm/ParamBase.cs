using System;

public class ParamBase
{
    protected BaseGrid m_searchGrid;
    protected Node m_startNode;
    protected Node m_endNode;

    public ParamBase(BaseGrid grid, GridPos StartPos, GridPos EndPos) : this(grid)
    {
        m_startNode = m_searchGrid.GetNodeAt(StartPos.x, StartPos.y);
        m_endNode = m_searchGrid.GetNodeAt(EndPos.x, EndPos.y);

        if (m_startNode == null)
            m_startNode = new Node(StartPos.x, StartPos.y, true);
        if (m_endNode == null)
            m_endNode = new Node(EndPos.x, EndPos.y, true);
    }

    public ParamBase(BaseGrid grid)
    {
        m_searchGrid = grid;
        m_startNode = null;
        m_endNode = null;
    }

    public ParamBase(ParamBase param)
    {
        m_searchGrid = param.m_searchGrid;
        m_startNode = param.m_startNode;
        m_endNode = param.m_endNode;

    }

    public BaseGrid SearchGrid
    {
        get
        {
            return m_searchGrid;
        }
    }

    public Node StartNode
    {
        get
        {
            return m_startNode;
        }
    }
    public Node EndNode
    {
        get
        {
            return m_endNode;
        }
    }
}
