using UnityEngine;

public class ClearMapGenerator : MapGenerator
{
    private GameObject[] m_obstacle;
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

    public override void CreateObstacles(GameObject[] obstacles)
    {
        m_obstacle = obstacles;

        var amountOfObstacles = ((MapHeight * MapWidth) / MapDifficulty);
        var randY = 0.0f;
        var randX = 0.0f;
        var randObstacle = 0;
        var spaceTaken = 0;

        while (amountOfObstacles > 0)
        {

            randY = Random.Range(0.0f,  MapHeight * 1.1f - 1f);
            randX = Random.Range(0.0f, MapWidth * 1.1f - 1f);
            randObstacle = Random.Range(0, 4);

            Object.Instantiate(obstacles[randObstacle], new Vector3(randX, 0.0f, randY), Quaternion.identity);


            spaceTaken = randObstacle > 2 ? 4 : randObstacle == 0 ? 0 : 2;
            amountOfObstacles -= spaceTaken;
        }
    }

    public override void CreateStartAndFinish(GameObject start, GameObject end)
    {
        GameObject singleGridElement;

        int randomX = Random.Range(0, (int) MapWidth);
        int randomY = Random.Range(0, (int) MapHeight);

        while (gridArray[randomY][randomX].tag == "obstacle")
        {
            randomX = Random.Range(0, (int) MapWidth);
            randomY = Random.Range(0, (int) MapHeight);
        }

        var position = gridArray[randomY][randomX].transform.position;
        singleGridElement = Object.Instantiate(start, position, Quaternion.Euler(90, 0, 0));
        Object.Destroy(gridArray[randomY][randomX]);
        gridArray[randomY][randomX] = singleGridElement;

        int finishRandomX = randomX;
        int finishRandomY = randomY;

        while (finishRandomX == randomX && finishRandomY == randomY)
        {
            finishRandomX = Random.Range(0, (int) MapWidth);
            finishRandomY = Random.Range(0, (int) MapHeight);
        }

        position = gridArray[finishRandomY][finishRandomX].transform.position;
        singleGridElement = Object.Instantiate(end, position, Quaternion.Euler(90, 0, 0));
        Object.Destroy(gridArray[finishRandomY][finishRandomX]);
        gridArray[finishRandomY][finishRandomX] = singleGridElement;
    }
}
