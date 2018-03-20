using System.Collections.Generic;
using UnityEngine;

public class DepthFirstAlgorithm : PathFindingAlgorithm
{
    public DepthFirstAlgorithm(int height, int width) : base(height, width)
    {
        vertices = new CustomNode[height][];
        results = new List<CustomNode>();
        IsSearching = true;
    }

    public override void Search()
    {
        if (startNode == endNode)
        {
            results.Add(startNode);
        }
        else
        {
            startNode.isVisited = true;
            CheckVicinity(startNode);
        }
    }

    private void CheckVicinity(CustomNode currentNode)
    {
        if (IsSearching)
        {
            TilePaint(currentNode, new Color(0.8f, 1f, 0.8f, 1));

            List<CustomNode> neighbours = GetNeighbors(currentNode);

            if (neighbours.Count > 0)
            {
                foreach (CustomNode n in neighbours)
                {
                    if (!n.isVisited)
                    {
                        TilePaint(n, new Color(0, 1f, 0.2f, 1));
                        n.parent = currentNode;

                        if (n == endNode)
                        {
                            IsSearching = false;
                            Rewind(n.parent);
                        }
                        else
                        {
                            n.isVisited = true;
                            CheckVicinity(n);
                        }
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
            neighbors.Add(vertices[x][y - 1]);
        }
        if (x < vertices.Length - 1 && vertices[x + 1][y].isWalkable)
        {
            neighbors.Add(vertices[x + 1][y]);
        }
        if (y < vertices[x].Length - 1 && vertices[x][y + 1].isWalkable)
        {
            neighbors.Add(vertices[x][y + 1]);
        }
        if (x > 0 && vertices[x - 1][y].isWalkable)
        {
            neighbors.Add(vertices[x - 1][y]);
        }
        return neighbors;
    }
}
