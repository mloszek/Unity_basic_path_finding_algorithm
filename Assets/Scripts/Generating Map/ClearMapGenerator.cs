using UnityEngine;

public class ClearMapGenerator : MapGenerator
{
    public override void CreateMap(GameObject field)
    {
        base.CreateMap(field);
        CreateObstacles();
        CreateStartAndFinish();
    }

    public override void CreateObstacles()
    {
        var amountOfObstacles = ((MapProperties.height * MapProperties.width) / 4);
        var randY = 0;
        var randX = 0;

        while (amountOfObstacles > 0)
        {
            var sizeOfObstacle = 0;

            randY = Random.Range(0, MapProperties.height);
            randX = Random.Range(0, MapProperties.width);

            PlaceObstacles(randY, randX, out sizeOfObstacle);

            amountOfObstacles -= sizeOfObstacle;
        }
    }

    private void PlaceObstacles(int x, int y, out int sizeOfObstacle)
    {
        var i = 0;
        int size = 0;

        if (x < MapProperties.height - 1 && y < MapProperties.width - 1)
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
        else if (x < MapProperties.height - 1 && y == MapProperties.width - 1)
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
        else if (x == MapProperties.height - 1 && y < MapProperties.width - 1)
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

        int randomX = Random.Range(0, MapProperties.width);
        int randomY = Random.Range(0, MapProperties.height);

        while (gridArray[randomY][randomX].name == "o")
        {
            randomX = Random.Range(0, MapProperties.width);
            randomY = Random.Range(0, MapProperties.height);
        }

        singleGridTile = gridArray[randomY][randomX];
        singleGridTile.GetComponent<Renderer>().material.color = Color.yellow;
        singleGridTile.name = "s";

        int finishRandomX = randomX;
        int finishRandomY = randomY;

        while (finishRandomX == randomX && finishRandomY == randomY)
        {
            finishRandomX = Random.Range(0, MapProperties.width);
            finishRandomY = Random.Range(0, MapProperties.height);
        }

        singleGridTile = gridArray[Random.Range(0, MapProperties.height)][Random.Range(0, MapProperties.width)];
        singleGridTile.GetComponent<Renderer>().material.color = Color.blue;
        singleGridTile.name = "e";
    }
}
