using UnityEngine;

public class ClearMapGenerator : MapGenerator
{
    private GameObject m_obstacle;
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
    }

    public override void CreateObstacles(GameObject obstacle)
    {
        m_obstacle = obstacle;

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
        GameObject singleObstacle;

        var position = gridArray[x][y].transform.position;
        singleObstacle = Object.Instantiate(m_obstacle, position, Quaternion.Euler(90, 0, 0));
        Object.Destroy(gridArray[x][y]);
        gridArray[x][y] = singleObstacle;

        position = gridArray[x + 1][y + 1].transform.position;
        singleObstacle = Object.Instantiate(m_obstacle, position, Quaternion.Euler(90, 0, 0));
        Object.Destroy(gridArray[x + 1][y + 1]);
        gridArray[x + 1][y + 1] = singleObstacle;

        position = gridArray[x + 1][y].transform.position;
        singleObstacle = Object.Instantiate(m_obstacle, position, Quaternion.Euler(90, 0, 0));
        Object.Destroy(gridArray[x + 1][y]);
        gridArray[x + 1][y] = singleObstacle;

        position = gridArray[x][y + 1].transform.position;
        singleObstacle = Object.Instantiate(m_obstacle, position, Quaternion.Euler(90, 0, 0));
        Object.Destroy(gridArray[x][y + 1]);
        gridArray[x][y + 1] = singleObstacle;
    }

    private void Place2x1(int x, int y)
    {
        GameObject singleObstacle;

        var position = gridArray[x][y].transform.position;
        singleObstacle = Object.Instantiate(m_obstacle, position, Quaternion.Euler(90, 0, 0));
        Object.Destroy(gridArray[x][y]);
        gridArray[x][y] = singleObstacle;

        position = gridArray[x + 1][y].transform.position;
        singleObstacle = Object.Instantiate(m_obstacle, position, Quaternion.Euler(90, 0, 0));
        Object.Destroy(gridArray[x + 1][y]);
        gridArray[x + 1][y] = singleObstacle;
    }

    private void Place1x2(int x, int y)
    {
        GameObject singleObstacle;

        var position = gridArray[x][y].transform.position;
        singleObstacle = Object.Instantiate(m_obstacle, position, Quaternion.Euler(90, 0, 0));
        Object.Destroy(gridArray[x][y]);
        gridArray[x][y] = singleObstacle;

        position = gridArray[x][y + 1].transform.position;
        singleObstacle = Object.Instantiate(m_obstacle, position, Quaternion.Euler(90, 0, 0));
        Object.Destroy(gridArray[x][y + 1]);
        gridArray[x][y + 1] = singleObstacle;
    }

    private void PlacePoint(int x, int y)
    {
        GameObject singleObstacle;

        var position = gridArray[x][y].transform.position;
        singleObstacle = Object.Instantiate(m_obstacle, position, Quaternion.Euler(90, 0, 0));
        Object.Destroy(gridArray[x][y]);
        gridArray[x][y] = singleObstacle;
    }

    public override void CreateStartAndFinish(GameObject start, GameObject end)
    {
        GameObject singleGridElement;

        int randomX = Random.Range(0, MapWidth);
        int randomY = Random.Range(0, MapHeight);

        while (gridArray[randomY][randomX].tag == "obstacle")
        {
            randomX = Random.Range(0, MapWidth);
            randomY = Random.Range(0, MapHeight);
        }

        var position = gridArray[randomY][randomX].transform.position;
        singleGridElement = Object.Instantiate(start, position, Quaternion.Euler(90, 0, 0));
        Object.Destroy(gridArray[randomY][randomX]);
        gridArray[randomY][randomX] = singleGridElement;

        int finishRandomX = randomX;
        int finishRandomY = randomY;

        while (finishRandomX == randomX && finishRandomY == randomY)
        {
            finishRandomX = Random.Range(0, MapWidth);
            finishRandomY = Random.Range(0, MapHeight);
        }

        position = gridArray[finishRandomY][finishRandomX].transform.position;
        singleGridElement = Object.Instantiate(end, position, Quaternion.Euler(90, 0, 0));
        Object.Destroy(gridArray[finishRandomY][finishRandomX]);
        gridArray[finishRandomY][finishRandomX] = singleGridElement;
    }
}
