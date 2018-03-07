using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LoadedMapGenerator : MapGenerator
{
    public static void CreateMap(GameObject field)
    {
        GenerateGrid(field, out gridArray);
    }

    public static new void GenerateGrid(GameObject field, out GameObject[][] gridArray)
    {
        string[] unwrappedMapScheme = MapProperties.fields.Split('@');
        char[] fieldsSignatures = unwrappedMapScheme[0].ToCharArray();

        var height = Int32.Parse(unwrappedMapScheme[1]);
        var width = Int32.Parse(unwrappedMapScheme[2]);

        //setting proper screen sizes for camera
        SetScreenSizeForCamera(width, height);

        GameObject[][] tempArray = new GameObject[height][];

        var charIndex = 0;

        for (int i = 0; i < height; i++)
        {
            tempArray[i] = new GameObject[width];
            for (int j = 0; j < width; j++)
            {
                GameObject singleGridElement;
                singleGridElement = Instantiate(field, new Vector3(j * 1.1f, 0, i * 1.1f), Quaternion.Euler(90, 0, 0));

                switch (fieldsSignatures[charIndex])
                {
                    case 'f':
                        singleGridElement.name = "f";
                        break;
                    case 'o':
                        singleGridElement.GetComponent<Renderer>().material.color = Color.black;
                        singleGridElement.name = "o";
                        break;
                    case 's':
                        singleGridElement.GetComponent<Renderer>().material.color = Color.yellow;
                        singleGridElement.name = "s";
                        break;
                    case 'e':
                        singleGridElement.GetComponent<Renderer>().material.color = Color.blue;
                        singleGridElement.name = "e";
                        break;
                    default:
                        singleGridElement.name = "f";
                        break;
                }
                charIndex++;
                tempArray[i][j] = singleGridElement;
            }
        }
        gridArray = tempArray;
    }

    private static void SetScreenSizeForCamera(int x, int y)
    {
        MapProperties.width = x;
        MapProperties.height = y;
    }
}
