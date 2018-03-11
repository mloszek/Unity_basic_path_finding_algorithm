using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PathFindingAlgorithm
{
    public List<CustomNode> results;

    protected CustomNode[][] vertices;
    protected CustomNode startNode;
    protected CustomNode endNode;
    protected bool IsSearching;

    public void CreateGrid()
    {
        for (int i = 0; i < MapProperties.height; i++)
        {

            vertices[i] = new CustomNode[MapProperties.width];

            for (int j = 0; j < MapProperties.width; j++)
            {

                vertices[i][j] = new CustomNode(i, j);

                if (MapGenerator.gridArray[i][j].name != "o")
                {
                    vertices[i][j].isWalkable = true;
                }

                if (MapGenerator.gridArray[i][j].name == "s")
                    startNode = vertices[i][j];

                if (MapGenerator.gridArray[i][j].name == "e")
                    endNode = vertices[i][j];
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
        if (pathNode.parent != startNode)
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
