using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public Sprite[] tileSprites;

    public void UpdateTile( GameObject obj, SpriteRenderer renderer, Tile.TileType tileType )
    {
        switch( tileType )
        {
            case Tile.TileType.CEMENT:
                obj.transform.tag = "Point";
                renderer.color = Color.white;
                renderer.sprite = tileSprites[0];
                break;
            case Tile.TileType.CHECKER:
                obj.transform.tag = "Point";
                renderer.color = Color.white;
                renderer.sprite = tileSprites[1];
                break;
            case Tile.TileType.DIRT:
                obj.transform.tag = "Point";
                renderer.color = Color.white;
                renderer.sprite = tileSprites[2];
                break;
            case Tile.TileType.GRASS:
                obj.transform.tag = "Point";
                renderer.color = Color.white;
                renderer.sprite = tileSprites[3];
                break;
            case Tile.TileType.METAL:
                obj.transform.tag = "Point";
                renderer.color = Color.white;
                renderer.sprite = tileSprites[4];
                break;
            case Tile.TileType.RUG:
                obj.transform.tag = "Point";
                renderer.color = Color.white;
                renderer.sprite = tileSprites[5];
                break;
            case Tile.TileType.WOOD:
                obj.transform.tag = "Point";
                renderer.color = Color.white;
                renderer.sprite = tileSprites[6];
                break;
            case Tile.TileType.WALL:
                obj.transform.tag = "Wall";
                renderer.color = new Color( 1, 1, 1, 0 );
                renderer.sprite = tileSprites[7];
                break;
        }
    }
}
