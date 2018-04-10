using UnityEngine;

public abstract class Obstacle
{
    protected GameObject[][] gridArray;
    protected int posX;
    protected int posY;
    protected int SizeOfObstacle;

    public Obstacle(GameObject[][] givenGrid, int posX, int posY)
    {
        gridArray = givenGrid;
        this.posX = posX;
        this.posY = posY;
    }

    public int GetSizeOfObstacle()
    {
        return SizeOfObstacle;
    }

    public abstract bool CheckIfFits();
    public abstract void PlaceObstacle(GameObject obstacleTile);
}
