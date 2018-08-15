using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum TileType
    {
        CEMENT,
        CHECKER,
        DIRT,
        GRASS,
        METAL,
        RUG,
        WOOD,
        WALL
    }
    public TileType tileType;

    [ContextMenuItem( "Save", "UpdateTile" )]
    public string save = "right click to save";

    void UpdateTile( )
    {
        Debug.Log( "We Did a thing..." );
        LevelCreator lMan = FindObjectOfType<LevelCreator>( );
        lMan.UpdateTile( gameObject, GetComponent<SpriteRenderer>( ), tileType );
    }
}
