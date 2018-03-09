using System.Collections.Generic;
using UnityEngine;

public class AstarHandler
{
    private bool[][] walkableNodes;
    private int height;
    private int width;
    private GridPos startPos = null;
    private GridPos endPos = null;
    private List<GridPos> resultPathList;

    public AstarHandler(int height, int width)
    {
        this.height = height;
        this.width = width;
    }

    public void RunAlgorithm()
    {
        walkableNodes = new bool[height][];
        DenoteGrid();
        BaseGrid searchGrid = new BaseGrid(height, width, walkableNodes);
        ParamBase parameters = new ParamBase(searchGrid, startPos, endPos);
        resultPathList = AStarFinder.FindPath(parameters);
    }

    public void ShowResultOnMap()
    {
        foreach (GridPos p in resultPathList)
        {
            MapGenerator.gridArray[p.x][p.y].GetComponent<Renderer>().material.color = Color.red;
        }
    }

    public int GetResultLength()
    {
        return resultPathList.Count;
    }

    private void DenoteGrid()
    {
        for (int i = 0; i < MapProperties.height; i++)
        {
            walkableNodes[i] = new bool[width];
            for (int j = 0; j < width; j++)
            {
                if (MapGenerator.gridArray[i][j].name != "o")
                    walkableNodes[i][j] = true;

                if (MapGenerator.gridArray[i][j].name == "s")
                    startPos = new GridPos(i, j);

                if (MapGenerator.gridArray[i][j].name == "e")
                    endPos = new GridPos(i, j);
            }
        }
    }
}
