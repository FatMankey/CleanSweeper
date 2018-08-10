using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GonzoMovement : MonoBehaviour
{
    public enum MoveDirection
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
    public MoveDirection moveDirection;
    public Vector3 dir = Vector3.zero;
    public float moveSpeed = 5;
    public bool hasHitWall = false;
    public bool isReady = false;

    private MoveDirection startDir;
    private Vector3 startPos;

    void Start( )
    {
        hasHitWall = false;
        isReady = false;
        startDir = moveDirection;
        startPos = transform.position;
        ChangeDirection( moveDirection );
    }

    void Update( )
    {
        if( !hasHitWall && isReady )
            transform.Translate( dir * moveSpeed * Time.deltaTime );
    }

    void OnTriggerEnter( Collider other )
    {
        if( other.tag == "Point" )
        {
            TileBehaviour tb = other.GetComponentInChildren<TileBehaviour>( );
            if( tb != null )
                StartCoroutine( StartChangeDirection( tb.GetDirection( ) ) );
            Debug.Log( "We are hitting tiles" );
        }

        if( other.tag == "Wall" )
        {
            hasHitWall = true;
        }
    }

    IEnumerator StartChangeDirection( MoveDirection _dir )
    {
        yield return new WaitForSeconds( ( 1 / moveSpeed ) * 3 );
        //yield return new WaitForSeconds( moveSpeed / ( moveSpeed + 3 ));

        ChangeDirection( _dir );
    }
    void ChangeDirection( MoveDirection _dir )
    {
        switch ( _dir )
        {
            case MoveDirection.UP:
                dir = Vector3.up;
                break;
            case MoveDirection.LEFT:
                dir = Vector3.left;
                break;
            case MoveDirection.RIGHT:
                dir = Vector3.right;
                break;
            case MoveDirection.DOWN:
                dir = Vector3.down;
                break;
        }
    }

    public void OnStart( )
    {
        isReady = true;
        ChangeDirection( startDir );
    }

    public void Reset( )
    {
        hasHitWall = false;
        isReady = false;
        transform.position = startPos;
    }
}
