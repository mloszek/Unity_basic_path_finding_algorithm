using System.Collections.Generic;

public class BaseGrid
{
    public int Width { get; set; }
    public int Height { get; set; }

    private Node[][] m_nodes;
    private GridRect m_gridRect;

    public BaseGrid(int Width, int Height, bool[][] grid = null)
    {        
        this.Width = Width;
        this.Height = Height;
        m_gridRect = new GridRect();
        m_gridRect.minX = 0;
        m_gridRect.minY = 0;
        m_gridRect.maxX = Width - 1;
        m_gridRect.maxY = Height - 1;
        this.m_nodes = BuildNodes(Width, Height, grid);
    }    

    public GridRect GridRect
    {
        get { return m_gridRect; }
    }

    public bool SetWalkableAt(int x, int y, bool iWalkable)
    {
        m_nodes[x][y].walkable = iWalkable;
        return true;
    }

    public Node GetNodeAt(int x, int y)
    {
        return m_nodes[x][y];
    }

    public Node GetNodeAt(GridPos position)
    {
        return GetNodeAt(position.x, position.y);
    }

    public bool IsWalkableAt(int x, int y)
    {
        return IsInside(x, y) && m_nodes[x][y].walkable;
    }

    public bool IsWalkableAt(GridPos position)
    {
        return IsWalkableAt(position.x, position.y);
    }

    public bool SetWalkableAt(GridPos position, bool iWalkable)
    {
        return SetWalkableAt(position.x, position.y, iWalkable);
    }

    public bool IsInside(int x, int y)
    {
        return (x >= 0 && x < Width) && (y >= 0 && y < Height);
    }

    public bool IsInside(GridPos position)
    {
        return IsInside(position.x, position.y);
    }

    public List<Node> GetNeighbors(Node node)
    {
        int x = node.x;
        int y = node.y;

        List<Node> neighbors = new List<Node>();       

        GridPos pos = new GridPos();

        if (IsWalkableAt(pos.Set(x, y - 1)))
        {
            neighbors.Add(GetNodeAt(pos));
        }
        if (this.IsWalkableAt(pos.Set(x + 1, y)))
        {
            neighbors.Add(GetNodeAt(pos));
        }
        if (this.IsWalkableAt(pos.Set(x, y + 1)))
        {
            neighbors.Add(GetNodeAt(pos));
        }
        if (this.IsWalkableAt(pos.Set(x - 1, y)))
        {
            neighbors.Add(GetNodeAt(pos));
        }
        return neighbors;
    }

    private Node[][] BuildNodes(int height, int width, bool[][] iMatrix)
    {

        Node[][] tNodes = new Node[height][];
        for (int widthTrav = 0; widthTrav < height; widthTrav++)
        {
            tNodes[widthTrav] = new Node[width];
            for (int heightTrav = 0; heightTrav < width; heightTrav++)
            {
                tNodes[widthTrav][heightTrav] = new Node(widthTrav, heightTrav, null);
            }
        }

        for (int widthTrav = 0; widthTrav < height; widthTrav++)
        {
            for (int heightTrav = 0; heightTrav < width; heightTrav++)
            {
                if (iMatrix[widthTrav][heightTrav])
                {
                    tNodes[widthTrav][heightTrav].walkable = true;
                }
                else
                {
                    tNodes[widthTrav][heightTrav].walkable = false;
                }
            }
        }
        return tNodes;
    }

}