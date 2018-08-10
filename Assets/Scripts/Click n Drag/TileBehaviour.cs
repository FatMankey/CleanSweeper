using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    public GonzoMovement.MoveDirection moveDirection;

    void Start( )
    {
        Debug.Log( gameObject.name );
    }

    void Update( )
    {
        if( Input.GetKeyDown( KeyCode.Space ) )
        {
            Debug.Log( "We hit space from a tile" );
        }
    }

    public GonzoMovement.MoveDirection GetDirection( )
    {
        return moveDirection;
    }
}
