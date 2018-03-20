using UnityEngine;

public abstract class MapGenerator
{
    protected static int MapHeight;
    protected static int MapWidth;

    public static GameObject[][] gridArray;

    public MapGenerator(int height, int width)
    {
        MapHeight = height;
        MapWidth = width;        
    }

    public virtual void CreateMap(GameObject field)
    {
        GenerateGrid(field, out gridArray);
    }

    public abstract void CreateStartAndFinish();
    public abstract void CreateObstacles();

    protected void GenerateGrid(GameObject field, out GameObject[][] gridArray)
    {
        var height = MapHeight;
        var width = MapWidth;        

        GameObject[][] tempArray = new GameObject[height][];

        for (int i = 0; i < height; i++)
        {
            tempArray[i] = new GameObject[width];
            for (int j = 0; j < width; j++)
            {
                GameObject singleGridElement = Object.Instantiate(field, new Vector3(j * 1.1f, 0, i * 1.1f), Quaternion.Euler(90, 0, 0));
                singleGridElement.name = "f";
                tempArray[i][j] = singleGridElement;
            }
        }
        gridArray = tempArray;
    }
}
