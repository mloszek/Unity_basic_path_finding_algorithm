using UnityEngine;

public class Obstacle1x2 : Obstacle {

    public Obstacle1x2(GameObject[][] givenGrid, int posX, int posY) : base(givenGrid, posX, posY)
    {
        SizeOfObstacle = 2;
    }

    public override bool CheckIfFits()
    {
        if (posX < gridArray.Length && posY < gridArray[0].Length - 1)
        {
            if (gridArray[posX][posY].GetComponent<TileProperties>().currentTileType.Equals(TileType.FIELD)
                & gridArray[posX][posY + 1].GetComponent<TileProperties>().currentTileType.Equals(TileType.FIELD))
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

        position = gridArray[posX][posY + 1].transform.position;
        singleObstacle = Object.Instantiate(obstacleTile, position, Quaternion.Euler(90, 0, 0));
        Object.Destroy(gridArray[posX][posY + 1]);
        gridArray[posX][posY + 1] = singleObstacle;
    }
}
