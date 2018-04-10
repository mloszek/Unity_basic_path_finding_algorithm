using System;
using UnityEngine;

public class LoadedMapGenerator : MapGenerator
{
    private char[] fieldsFromSave;

    public LoadedMapGenerator(int height, int width) : base(height, width) { }

    public override void CreateMap(GameObject field)
    {
        fieldsFromSave = SaveLoadScript.savedMap[0].ToCharArray();
        base.CreateMap(field);
    }

    public override void CreateObstacles(GameObject obstacle)
    {
        DrawMapElements('o', obstacle);
    }

    public override void CreateStartAndFinish(GameObject start, GameObject end)
    {
        DrawMapElements('s', start);
        DrawMapElements('e', end);
    }

    private void DrawMapElements(char sign, GameObject field)
    {
        GameObject singleObstacle;
        var index = 0;

        for (int i = 0; i < gridArray.Length; i++)
        {
            for (int j = 0; j < gridArray[i].Length; j++)
            {
                if (fieldsFromSave[index++] == sign)
                {
                    var position = gridArray[i][j].transform.position;
                    singleObstacle = UnityEngine.Object.Instantiate(field, position, Quaternion.Euler(90, 0, 0));
                    UnityEngine.Object.Destroy(gridArray[i][j]);
                    gridArray[i][j] = singleObstacle;
                }
            }
        }
    }
}
