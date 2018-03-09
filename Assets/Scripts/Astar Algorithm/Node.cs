using System;
using System.Collections.Generic;
using UnityEngine;

public class Node : IComparable<Node>
{
    public int x;
    public int y;
    public bool walkable;
    public float heuristicStartToEndLen;
    public float startToCurNodeLen;
    public float? heuristicCurNodeToEndLen;
    public bool isOpened;
    public bool isClosed;
    public System.Object parent;
    public GameObject childField;

    public Node(int x, int y, bool? iWalkable = null)
    {
        this.x = x;
        this.y = y;
        this.walkable = (iWalkable.HasValue ? iWalkable.Value : false);
        this.heuristicStartToEndLen = 0;
        this.startToCurNodeLen = 0;
        this.heuristicCurNodeToEndLen = null;
        this.isOpened = false;
        this.isClosed = false;
        this.parent = null;
        this.childField = MapGenerator.gridArray[x][y];
    }

    public Node(Node b)
    {
        this.x = b.x;
        this.y = b.y;
        this.walkable = b.walkable;
        this.heuristicStartToEndLen = b.heuristicStartToEndLen;
        this.startToCurNodeLen = b.startToCurNodeLen;
        this.heuristicCurNodeToEndLen = b.heuristicCurNodeToEndLen;
        this.isOpened = b.isOpened;
        this.isClosed = b.isClosed;
        this.parent = b.parent;
    }

    public int CompareTo(Node node)
    {
        float result = this.heuristicStartToEndLen - node.heuristicStartToEndLen;
        if (result > 0.0f)
        {
            return 1;
        }
        else if (result == 0.0f)
        {
            return 0;
        }
        return -1;
    }

    public static List<GridPos> Backtrace(Node node)
    {
        List<GridPos> path = new List<GridPos>();
        path.Add(new GridPos(node.x, node.y));
        while (node.parent != null)
        {
            node = (Node)node.parent;
            path.Add(new GridPos(node.x, node.y));
        }
        path.Reverse();
        return path;
    }


    public override int GetHashCode()
    {
        return x ^ y;
    }

    public override bool Equals(System.Object obj)
    {
        if (obj == null)
        {
            return false;
        }
        
        Node p = obj as Node;
        if ((System.Object)p == null)
        {
            return false;
        }
        
        return (x == p.x) && (y == p.y);
    }

    public bool Equals(Node p)
    {
        if ((object)p == null)
        {
            return false;
        }

        return (x == p.x) && (y == p.y);
    }

    public static bool operator ==(Node a, Node b)
    {
        if (System.Object.ReferenceEquals(a, b))
        {
            return true;
        }

        if (((object)a == null) || ((object)b == null))
        {
            return false;
        }

        return a.x == b.x && a.y == b.y;
    }

    public static bool operator !=(Node a, Node b)
    {
        return !(a == b);
    }
}
