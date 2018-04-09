using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileProperties : MonoBehaviour {

    public enum tileType
    {
        FIELD,
        OBSTACLE,
        START,
        END
    };

    public tileType currentTileType;
    
}
