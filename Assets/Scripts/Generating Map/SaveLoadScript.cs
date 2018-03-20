using System;
using System.Text;
using System.IO;
using UnityEngine;

public static class SaveLoadScript
{
    public static string[] savedMap;

    public static void Save()
    {
        File.WriteAllText(Application.persistentDataPath + "\\save.crp", MakeSave());
    }

    public static void Load()
    {
        savedMap =  File.ReadAllText(Application.persistentDataPath + "\\save.crp").Split('@');
        MapProperties.width = Int32.Parse(savedMap[1]);
        MapProperties.height = Int32.Parse(savedMap[2]);
    }

    public static string MakeSave()
    {
        StringBuilder gridOrder = new StringBuilder();
        GameObject[][] gridArray = MapGenerator.gridArray;

        for (int i = 0; i < gridArray.Length; i++)
        {
            for (int j = 0; j < gridArray[i].Length; j++)
            {
                gridOrder.Append(gridArray[i][j].tag.Substring(0, 1));
            }
        }
        gridOrder.Append("@");
        gridOrder.Append(gridArray[0].Length);
        gridOrder.Append("@");
        gridOrder.Append(gridArray.Length);

        return gridOrder.ToString();
    }
}
