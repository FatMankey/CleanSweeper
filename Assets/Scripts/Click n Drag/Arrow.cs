using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    // the arrow script will have a reference to it's
    // tile object. This tile object will be a 
    // prefab that will become a child to the tile
    // it is currently hovered over
    
    public TileBehaviour tileBehaviour;
    public List<GameObject> ListOfTiles;
    public Text NumberOfArrowsText;
    public int numberOfArrows = 5;
    public bool isOutOfArrows = false;

    private GameObject tile;
    private Vector3 mousePos;
    private int _numberOfArrows = 0;

    void Start( )
    {
        tile = null;
        _numberOfArrows = numberOfArrows;
        isOutOfArrows = _numberOfArrows > 0 ? false : true;
        foreach( GameObject go in GameObject.FindGameObjectsWithTag( "Point" ) )
        {
            ListOfTiles.Add( go );
        }

        NumberOfArrowsText.text = "x" + _numberOfArrows.ToString();
    }

    public void OnBeginDrag( )
    {
        if( isOutOfArrows )
            return;
        tile = (GameObject)Instantiate( tileBehaviour.gameObject, transform.position, Quaternion.identity );
    }

    public void OnDrag( )
    {
        if( isOutOfArrows )
            return;
        mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        mousePos.z = 0;
        tile.transform.position = mousePos;
    }

    public void OnEndDrag( )
    {
        if( isOutOfArrows )
            return;
        PlaceTile( mousePos );
        if( tile != null )
            Destroy( tile );
    }

    void PlaceTile( Vector3 pos )
    {
        bool isInATile;

        for( int i = 0; i < ListOfTiles.Count; i++ )
        {
            isInATile = false;

            int leftA = (int)pos.x;
            int rightA = (int)pos.x;
            int topA = (int)pos.y;
            int bottomA = (int)pos.y;
            
            int leftB = (int)ListOfTiles[i].transform.position.x;
            int rightB = (int)ListOfTiles[i].transform.position.x * (int)ListOfTiles[i].transform.localScale.x;
            int topB = (int)ListOfTiles[i].transform.position.y;
            int bottomB = (int)ListOfTiles[i].transform.position.y * (int)ListOfTiles[i].transform.localScale.y;

            //Debug.Log( leftA + ":" + rightA + ":" + topA + ":" + bottomA + "__" + leftB + ":" + rightB + ":" + topB + ":" + bottomB );

            if( leftA == leftB && rightA == rightB && topA == topB && bottomA == bottomB )
                isInATile = true;

            if( isInATile )
            {
                Debug.Log( "We Have A MATCH!!!!!" );
                if( ListOfTiles[i].GetComponentInChildren<TileBehaviour>( ) == null )
                {
                    tile.transform.parent = ListOfTiles[i].transform;
                    tile.transform.localPosition = Vector3.zero;
                    tile = null;
                    _numberOfArrows--;
                    NumberOfArrowsText.text = "x" + _numberOfArrows.ToString();
                    isOutOfArrows = _numberOfArrows > 0 ? false : true;
                }
                break;
            }
        }
    }

    public void Reset( )
    {
        Debug.Log( "Reset arrow" );
        _numberOfArrows = numberOfArrows;
        isOutOfArrows = _numberOfArrows > 0 ? false : true;
        NumberOfArrowsText.text = "x" + _numberOfArrows.ToString();
        tile = null;

        for( int i = 0; i < ListOfTiles.Count; i++ )
        {
            if( ListOfTiles[i].transform.childCount > 0 )
            {
                Destroy( ListOfTiles[i].transform.GetChild(0).gameObject );
            }
        }
    }
}
