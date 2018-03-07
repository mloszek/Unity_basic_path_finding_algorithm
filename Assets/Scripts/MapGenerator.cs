﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class MapGenerator : MonoBehaviour
{
    public static GameObject[][] gridArray;

    public static void GenerateGrid(GameObject field, out GameObject[][] gridArray)
    {
        var height = MapProperties.height;
        var width = MapProperties.width;        

        GameObject[][] tempArray = new GameObject[height][];

        for (int i = 0; i < height; i++)
        {
            tempArray[i] = new GameObject[width];
            for (int j = 0; j < width; j++)
            {
                var singleGridElement = Instantiate(field, new Vector3(j * 1.1f, 0, i * 1.1f), Quaternion.Euler(90, 0, 0));
                singleGridElement.name = "f";
                tempArray[i][j] = (GameObject) singleGridElement;
            }
        }
        gridArray = tempArray;
    }

    public static string SaveMap()
    {
        StringBuilder gridOrder = new StringBuilder();
        for (int i = 0; i < gridArray.Length; i++)
        {
            for (int j = 0; j < gridArray[i].Length; j++)
            {
                gridOrder.Append(gridArray[i][j].name);
            }
        }
        gridOrder.Append("@");
        gridOrder.Append(gridArray.Length);
        gridOrder.Append("@");
        gridOrder.Append(gridArray[0].Length);

        return gridOrder.ToString();
    }
}
