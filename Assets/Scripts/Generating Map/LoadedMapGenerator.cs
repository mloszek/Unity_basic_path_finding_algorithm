using System;
using UnityEngine;

public class LoadedMapGenerator : MapGenerator
{
    private char[] fieldsFromSave;

    public override void CreateMap(GameObject field)
    {
        fieldsFromSave = SaveLoadScript.savedMap[0].ToCharArray();
        base.CreateMap(field);
        CreateObstacles();
        CreateStartAndFinish();        
    }

    public override void CreateObstacles()
    {
        DrawMapElements('o', Color.black);
    }

    public override void CreateStartAndFinish()
    {
        DrawMapElements('s', Color.yellow);
        DrawMapElements('e', Color.blue);
    }

    private void DrawMapElements(char sign, Color color)
    {
        var index = 0;

        for (int i = 0; i < gridArray.Length; i++)
        {
            for (int j = 0; j < gridArray[i].Length; j++)
            {
                if(fieldsFromSave[index++] == sign)
                {
                    var field = gridArray[i][j];
                    field.name = sign.ToString();
                    field.GetComponent<Renderer>().material.color = color;
                }
            }
        }
    }
}
