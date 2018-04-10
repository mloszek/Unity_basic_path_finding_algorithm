using UnityEngine;

public class Obstacle2x2 : Obstacle {

    public Obstacle2x2(GameObject[][] givenGrid, int posX, int posY) : base(givenGrid, posX, posY)
    {
        SizeOfObstacle = 4;
    }

    public override bool CheckIfFits()
    {
        if (posX < gridArray.Length - 1 && posY < gridArray[0].Length - 1)
        {
            if (gridArray[posX][posY].GetComponent<TileProperties>().currentTileType.Equals(TileType.FIELD)
                & gridArray[posX + 1][posY].GetComponent<TileProperties>().currentTileType.Equals(TileType.FIELD)
                & gridArray[posX][posY + 1].GetComponent<TileProperties>().currentTileType.Equals(TileType.FIELD)
                & gridArray[posX + 1][posY + 1].GetComponent<TileProperties>().currentTileType.Equals(TileType.FIELD))
            {
                return true;
            }
        }
        return false;
    }

    public override void PlaceObstacle(GameObject obstacleTile)
    {
        GameObject singleObstacle;

        var position = gridArray[posX][posY].transform.position;
        singleObstacle = Object.Instantiate(obstacleTile, position, Quaternion.Euler(90, 0, 0));
        Object.Destroy(gridArray[posX][posY]);
        gridArray[posX][posY] = singleObstacle;

        position = gridArray[posX + 1][posY].transform.position;
        singleObstacle = Object.Instantiate(obstacleTile, position, Quaternion.Euler(90, 0, 0));
        Object.Destroy(gridArray[posX + 1][posY]);
        gridArray[posX + 1][posY] = singleObstacle;

        position = gridArray[posX][posY + 1].transform.position;
        singleObstacle = Object.Instantiate(obstacleTile, position, Quaternion.Euler(90, 0, 0));
        Object.Destroy(gridArray[posX][posY + 1]);
        gridArray[posX][posY + 1] = singleObstacle;

        position = gridArray[posX + 1][posY + 1].transform.position;
        singleObstacle = Object.Instantiate(obstacleTile, position, Quaternion.Euler(90, 0, 0));
        Object.Destroy(gridArray[posX + 1][posY + 1]);
        gridArray[posX + 1][posY + 1] = singleObstacle;
    }
}
