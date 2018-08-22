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
    public Sprite[] anims;
    public Vector3 dir = Vector3.zero;
    public float moveSpeed = 5;
    public bool hasHitGoal = false;
    public bool hasHitWall = false;
    public bool isReady = false;
    public bool isRotating = false;

    private ButtonManager bMan;
    private MoveDirection startDir;
    private SpriteRenderer spriteRenderer;
    private Vector3 startPos;

    public void OnInit( )
    {
        bMan = FindObjectOfType<ButtonManager>( );
        spriteRenderer = GetComponentInChildren<SpriteRenderer>( );
        hasHitGoal = false;
        hasHitWall = false;
        isReady = false;
        isRotating = false;
        startDir = moveDirection;
        startPos = transform.position;
        ChangeDirection( moveDirection );
    }

    void Update( )
    {
        if( hasHitGoal || isRotating )
            return;

        if( !hasHitWall && isReady )
            transform.Translate( dir * moveSpeed * Time.deltaTime );
    }

    void OnTriggerEnter( Collider other )
    {
        if( other.tag == "Point" )
        {
            TileBehaviour tb = other.GetComponentInChildren<TileBehaviour>( );
            if( tb != null )
                StartCoroutine( StartChangeDirection( tb.GetDirection( ), tb.gameObject ) );
            Debug.Log( "We are hitting tiles" );
        }

        if( other.tag == "Goal" )
        {
            StartCoroutine( StartWinGame( ) );
        }

        if( other.tag == "Wall" )
        {
            hasHitWall = true;
        }
    }

    IEnumerator StartChangeDirection( MoveDirection _dir, GameObject obj )
    {
        yield return new WaitForSeconds( ( 1 / moveSpeed ) * 3 );
        isRotating = true;
        transform.position = obj.transform.position;
        yield return new WaitForSeconds( 0.5f );
        isRotating = false;
        ChangeDirection( _dir );
    }

    IEnumerator StartWinGame( )
    {
        yield return new WaitForSeconds( ( 1 / moveSpeed ) * 3 );
        hasHitGoal = true;
        bMan.OnEnterGoal( );
    }

    void ChangeDirection( MoveDirection _dir )
    {
        switch ( _dir )
        {
            case MoveDirection.UP:
                dir = Vector3.up;
                spriteRenderer.flipX = false;
                spriteRenderer.sprite = anims[0];
                break;
            case MoveDirection.LEFT:
                dir = Vector3.left;
                spriteRenderer.flipX = false;
                spriteRenderer.sprite = anims[1];
                break;
            case MoveDirection.RIGHT:
                dir = Vector3.right;
                spriteRenderer.flipX = true;
                spriteRenderer.sprite = anims[1];
                break;
            case MoveDirection.DOWN:
                dir = Vector3.down;
                spriteRenderer.flipX = false;
                spriteRenderer.sprite = anims[2];
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
        hasHitGoal = false;
        hasHitWall = false;
        isReady = false;
        transform.position = startPos;
    }
}
