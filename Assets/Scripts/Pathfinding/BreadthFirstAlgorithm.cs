using System.Collections.Generic;
using UnityEngine;

public class BreadthFirstAlgorithm : PathFindingAlgorithm
{
    private Queue<CustomNode> queue;
    private CustomNode node;
    private bool isFastExit;

    public BreadthFirstAlgorithm(int height, int width, bool isFast) : base (height, width)
    {
        vertices = new CustomNode[height][];
        queue = new Queue<CustomNode>();
        results = new List<CustomNode>();
        isFastExit = isFast;
    }

    public override void Search()
    {
        if (startNode == endNode)
        {
            results.Add(startNode);
        }
        else
        {
            queue.Enqueue(startNode);
            CheckVicinity();
        }
    }

    private void CheckVicinity()
    {
        while (queue.Count > 0)
        {
            node = queue.Dequeue();

            TilePaint(node, new Color(0.8f, 1f, 0.8f, 1));

            List<CustomNode> neighbours = GetNeighbors(node);

            if (neighbours.Count > 0)
            {
                foreach (CustomNode n in neighbours)
                {
                    TilePaint(n, new Color(0, 1f, 0.2f, 1));
                    n.isVisited = true;
                    n.parent = node;

                    if (n == endNode)
                    {
                        IsSearching = false;
                        Rewind(n.parent);
                        if (isFastExit)
                        {
                            queue.Clear();
                        }
                        break;
                    }
                    else
                    {
                        queue.Enqueue(n);
                    }
                }
            }
        }
    }

    protected override List<CustomNode> GetNeighbors(CustomNode currentNode)
    {
        int x = currentNode.x;
        int y = currentNode.y;

        List<CustomNode> neighbors = new List<CustomNode>();

        if (y > 0 && vertices[x][y - 1].isWalkable)
        {
            if (!vertices[x][y - 1].isVisited)
            {
                neighbors.Add(vertices[x][y - 1]);
            }
        }
        if (x < vertices.Length - 1 && vertices[x + 1][y].isWalkable)
        {
            if (!vertices[x + 1][y].isVisited)
            {
                neighbors.Add(vertices[x + 1][y]);
            }
        }
        if (y < vertices[x].Length - 1 && vertices[x][y + 1].isWalkable)
        {
            if (!vertices[x][y + 1].isVisited)
            {
                neighbors.Add(vertices[x][y + 1]);
            }
        }
        if (x > 0 && vertices[x - 1][y].isWalkable)
        {
            if (!vertices[x - 1][y].isVisited)
            {
                neighbors.Add(vertices[x - 1][y]);
            }
        }
        return neighbors;
    }
}

