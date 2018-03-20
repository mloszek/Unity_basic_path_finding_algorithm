using UnityEngine;

public class ClearMapGenerator : MapGenerator
{
    private int MapDifficulty;

    public ClearMapGenerator(int height, int width, int difficulty) : base(height, width)
    {
        MapHeight = height;
        MapWidth = width;
        MapDifficulty = difficulty;
    }

    public override void CreateMap(GameObject field)
    {
        base.CreateMap(field);
        CreateObstacles();
        CreateStartAndFinish();
    }

    public override void CreateObstacles()
    {
        var amountOfObstacles = ((MapHeight * MapWidth) / MapDifficulty);
        var randY = 0;
        var randX = 0;

        while (amountOfObstacles > 0)
        {
            var sizeOfObstacle = 0;

            randY = Random.Range(0, MapHeight);
            randX = Random.Range(0, MapWidth);

            PlaceObstacles(randY, randX, out sizeOfObstacle);

            amountOfObstacles -= sizeOfObstacle;
        }
    }

    private void PlaceObstacles(int x, int y, out int sizeOfObstacle)
    {
        var i = 0;
        int size = 0;

        if (x < MapHeight - 1 && y < MapWidth - 1)
        {
            i = Random.Range(0, 4);
            switch (i)
            {
                case 0:
                    Place2x2(x, y);
                    size = 4;
                    break;
                case 1:
                    Place2x1(x, y);
                    size = 2;
                    break;
                case 2:
                    Place1x2(x, y);
                    size = 2;
                    break;
                case 3:
                    PlacePoint(x, y);
                    size = 1;
                    break;
            }
        }
        else if (x < MapHeight - 1 && y == MapWidth - 1)
        {
            i = Random.Range(0, 2);
            switch (i)
            {
                case 0:
                    Place2x1(x, y);
                    size = 2;
                    break;
                case 1:
                    PlacePoint(x, y);
                    size = 1;
                    break;
            }
        }
        else if (x == MapHeight - 1 && y < MapWidth - 1)
        {
            i = Random.Range(0, 2);
            switch (i)
            {
                case 0:
                    Place1x2(x, y);
                    size = 2;
                    break;
                case 1:
                    PlacePoint(x, y);
                    size = 1;
                    break;
            }
        }
        else
        {
            PlacePoint(x, y);
            size = 1;
        }
        sizeOfObstacle = size;
    }

    private void Place2x2(int x, int y)
    {
        gridArray[x][y].name = "o";
        gridArray[x][y].GetComponent<Renderer>().material.color = Color.black;
        gridArray[x + 1][y + 1].name = "o";
        gridArray[x + 1][y + 1].GetComponent<Renderer>().material.color = Color.black;
        gridArray[x + 1][y].name = "o";
        gridArray[x + 1][y].GetComponent<Renderer>().material.color = Color.black;
        gridArray[x][y + 1].name = "o";
        gridArray[x][y + 1].GetComponent<Renderer>().material.color = Color.black;
    }

    private void Place2x1(int x, int y)
    {
        gridArray[x][y].name = "o";
        gridArray[x][y].GetComponent<Renderer>().material.color = Color.black;
        gridArray[x + 1][y].name = "o";
        gridArray[x + 1][y].GetComponent<Renderer>().material.color = Color.black;
    }

    private void Place1x2(int x, int y)
    {
        gridArray[x][y].name = "o";
        gridArray[x][y].GetComponent<Renderer>().material.color = Color.black;
        gridArray[x][y + 1].name = "o";
        gridArray[x][y + 1].GetComponent<Renderer>().material.color = Color.black;
    }

    private void PlacePoint(int x, int y)
    {
        gridArray[x][y].name = "o";
        gridArray[x][y].GetComponent<Renderer>().material.color = Color.black;
    }

    public override void CreateStartAndFinish()
    {
        GameObject singleGridTile;

        int randomX = Random.Range(0, MapWidth);
        int randomY = Random.Range(0, MapHeight);

        while (gridArray[randomY][randomX].name == "o")
        {
            randomX = Random.Range(0, MapWidth);
            randomY = Random.Range(0, MapHeight);
        }

        singleGridTile = gridArray[randomY][randomX];
        singleGridTile.GetComponent<Renderer>().material.color = Color.yellow;
        singleGridTile.name = "s";

        int finishRandomX = randomX;
        int finishRandomY = randomY;

        while (finishRandomX == randomX && finishRandomY == randomY)
        {
            finishRandomX = Random.Range(0, MapWidth);
            finishRandomY = Random.Range(0, MapHeight);
        }

        singleGridTile = gridArray[finishRandomY][finishRandomX];
        singleGridTile.GetComponent<Renderer>().material.color = Color.blue;
        singleGridTile.name = "e";
    }
}
