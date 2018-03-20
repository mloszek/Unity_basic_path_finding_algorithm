using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PathFindingAlgorithm
{
    public List<CustomNode> results;

    protected int MapHeight;
    protected int MapWidth;

    protected CustomNode[][] vertices;
    protected CustomNode startNode;
    protected CustomNode endNode;
    protected bool IsSearching;

    protected PathFindingAlgorithm(int height, int width)
    {
        MapHeight = height;
        MapWidth = width;
    }

    public void CreateGrid()
    {
        for (int i = 0; i < MapHeight; i++)
        {

            vertices[i] = new CustomNode[MapWidth];

            for (int j = 0; j < MapWidth; j++)
            {

                vertices[i][j] = new CustomNode(i, j);

                if (MapGenerator.gridArray[i][j].tag != "obstacle")
                {
                    vertices[i][j].isWalkable = true;
                }

                if (MapGenerator.gridArray[i][j].tag == "start")
                {
                    startNode = vertices[i][j];
                }

                if (MapGenerator.gridArray[i][j].tag == "end")
                {
                    endNode = vertices[i][j];
                }
            }
        }
    }

    public void ShowPath()
    {
        foreach (CustomNode n in results)
        {
            TilePaint(n, new Color(1, 0.4f, 0.4f, 1));
        }
        TilePaint(startNode, Color.yellow);
        TilePaint(endNode, Color.blue);
    }

    protected void Rewind(CustomNode pathNode)
    {
        results.Add(pathNode);
        if (pathNode != startNode && pathNode.parent != startNode)
        {
            Rewind(pathNode.parent);
        }
    }    

    protected void TilePaint(CustomNode paintNode, Color color)
    {
        MapGenerator.gridArray[paintNode.x][paintNode.y].GetComponent<Renderer>()
                .material.color = color;
    }

    public abstract void Search();
    protected abstract List<CustomNode> GetNeighbors(CustomNode currentNode);
}
