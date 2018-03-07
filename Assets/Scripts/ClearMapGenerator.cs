using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearMapGenerator : MapGenerator
{
    public static void CreateMap(GameObject field)
    {
        GenerateGrid(field, out gridArray);
        CreateStartAndFinish();
    }

    static void CreateStartAndFinish()
    {
        GameObject field = gridArray[Random.Range(0, MapProperties.width)][Random.Range(0, MapProperties.height)];
        field.GetComponent<Renderer>().material.color = Color.yellow;
        field.name = "s";
        field = gridArray[Random.Range(0, MapProperties.height)][Random.Range(0, MapProperties.width)];
        field.GetComponent<Renderer>().material.color = Color.blue;
        field.name = "e";
    }
}
