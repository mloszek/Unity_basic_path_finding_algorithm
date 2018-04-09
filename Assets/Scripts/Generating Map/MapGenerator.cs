using UnityEngine;

public abstract class MapGenerator
{
    protected static float MapHeight;
    protected static float MapWidth;

    public static GameObject[][] gridArray;

    public MapGenerator(float height, float width)
    {
        MapHeight = height;
        MapWidth = width;        
    }

    public virtual void CreateMap(GameObject field)
    {
        GenerateGrid(field, out gridArray);
    }

    public abstract void CreateStartAndFinish(GameObject start, GameObject finish);
    public abstract void CreateObstacles(GameObject[] obstacle);

    protected void GenerateGrid(GameObject field, out GameObject[][] gridArray)
    {
        var height = MapHeight;
        var width = MapWidth;        

        GameObject[][] tempArray = new GameObject[(int)height][];

        for (int i = 0; i < height; i++)
        {
            tempArray[i] = new GameObject[(int)width];
            for (int j = 0; j < width; j++)
            {
                GameObject singleGridElement = Object.Instantiate(field, new Vector3(j * 1.1f, 0, i * 1.1f), Quaternion.Euler(90, 0, 0));
                tempArray[i][j] = singleGridElement;
            }
        }
        gridArray = tempArray;
    }
}
