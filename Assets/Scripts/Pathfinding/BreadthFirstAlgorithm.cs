using System.Collections.Generic;
using UnityEngine;

public class BreadthFirstAlgorithm : PathFindingAlgorithm
{
    private Queue<CustomNode> queue;
    private CustomNode node;

    private delegate bool IsFastEnd();
    private static event IsFastEnd Conditions;

    public BreadthFirstAlgorithm()
    {
        InitializeAlgorithm();
        Conditions += IsQueueCountPositive;
    }

    public BreadthFirstAlgorithm(bool fastEnd)
    {
        InitializeAlgorithm();
        Conditions += IsQueueCountPositive;
        if (fastEnd)
        {
            Conditions += IsStillSearching;
        }
    }

    private void InitializeAlgorithm()
    {
        vertices = new CustomNode[MapProperties.height][];
        queue = new Queue<CustomNode>();
        results = new List<CustomNode>();
        IsSearching = true;
    }

    public bool IsQueueCountPositive()
    {
        return queue.Count > 0;
    }

    public bool IsStillSearching()
    {
        return IsSearching;
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
        while (Conditions())
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

