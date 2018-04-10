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
    }

    public override void CreateObstacles(GameObject obstacle)
    {
        Obstacle obstacleToPlace = null;
        var amountOfObstacles = ((MapHeight * MapWidth) / MapDifficulty);
        var randY = 0;
        var randX = 0;
        var randObstacle = 0;
        var actualObstacleSpace = 0;

        while (amountOfObstacles > 0)
        {
            randY = Random.Range(0,  MapHeight);
            randX = Random.Range(0, MapWidth);
            randObstacle = Random.Range(0, 4);

            switch (randObstacle)
            {
                case 0:
                   obstacleToPlace =  new Obstacle1x1(gridArray, randY, randX);
                    break;
                case 1:
                    obstacleToPlace = new Obstacle1x2(gridArray, randY, randX);
                    break;
                case 2:
                    obstacleToPlace = new Obstacle2x1(gridArray, randY, randX);
                    break;
                case 3:
                    obstacleToPlace = new Obstacle2x2(gridArray, randY, randX);
                    break;
                default:
                    obstacleToPlace = new Obstacle1x1(gridArray, randY, randX);
                    break;
            }
            
            if (obstacleToPlace.CheckIfFits())
            {
                obstacleToPlace.PlaceObstacle(obstacle);
                actualObstacleSpace = obstacleToPlace.GetSizeOfObstacle();
                amountOfObstacles -= actualObstacleSpace;
            }            
        }
    }  

    public override void CreateStartAndFinish(GameObject start, GameObject end)
    {
        GameObject singleGridElement;

        int randomX = Random.Range(0, (int) MapWidth);
        int randomY = Random.Range(0, (int) MapHeight);

        while (gridArray[randomY][randomX].GetComponent<TileProperties>().currentTileType.Equals(TileType.OBSTACLE))
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

        while (!gridArray[finishRandomY][finishRandomX].GetComponent<TileProperties>().currentTileType.Equals(TileType.FIELD))
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
