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
    public Image NumberImage; 
    public Sprite[] NumberSprites;
    public int numberOfArrows = 5;
    public bool isOutOfArrows = false;
    
    private List<GameObject> myTiles;
    private GameObject tile;
    private Vector3 mousePos;
    private int _numberOfArrows = 0;

    public void OnInit( int num )
    {
        myTiles = new List<GameObject>( );
        tile = null;
        numberOfArrows = num;
        _numberOfArrows = numberOfArrows;
        isOutOfArrows = _numberOfArrows > 0 ? false : true;
        foreach( GameObject go in GameObject.FindGameObjectsWithTag( "Point" ) )
        {
            ListOfTiles.Add( go );
        }
        NumberImage.sprite = NumberSprites[_numberOfArrows];
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

        RaycastHit hit; 
        Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition ); 
        if( Physics.Raycast( ray, out hit ) )
        {
            if( hit.collider.gameObject.tag == "Point" )
            {
                if( hit.collider.GetComponentInChildren<TileBehaviour>( ) == null )
                {                    
                    tile.transform.parent = hit.collider.gameObject.transform;
                    tile.transform.localPosition = Vector3.zero;
                    myTiles.Add( tile );
                    tile = null;
                    _numberOfArrows--;
                    NumberImage.sprite = NumberSprites[_numberOfArrows];
                    isOutOfArrows = _numberOfArrows > 0 ? false : true;
                }
            }
        }

        /*bool isInATile;
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
        }*/
    }

    public void Reset( )
    {
        Debug.Log( "Reset arrow" );
        _numberOfArrows = numberOfArrows;
        isOutOfArrows = _numberOfArrows > 0 ? false : true;
        NumberImage.sprite = NumberSprites[_numberOfArrows];
        tile = null;

        if( myTiles.Count > 0 )
        {
            for( int i = myTiles.Count - 1; i >= 0; i-- )
            {
                Destroy( myTiles[i] );
            }
        }

        ListOfTiles.Clear();
    }
}
