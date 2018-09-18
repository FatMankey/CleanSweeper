using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhoombaAnimationManager : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sprite;

    public void Init( )
    {
        animator = GetComponent<Animator>( );
        sprite = GetComponent<SpriteRenderer>( );
    }

    public void PlaySideSleep( bool flip )
    {
        animator.Play( "Side_Sleep" );
        sprite.flipX = flip;
    }
    public void PlaySideWakeUp( bool flip )
    {
        animator.Play( "Side_WakeUp" );
        sprite.flipX = flip;
    }
    public void PlaySideMoving( bool flip )
    {
        animator.Play( "Side_Moving" );
        sprite.flipX = flip;
    }

    public void PlayDownSleep( )
    {
        animator.Play( "Down_Sleep" );
    }
    public void PlayDownWakeUp( )
    {
        animator.Play( "Down_WakeUp" );
    }
    public void PlayDownMoving( )
    {
        animator.Play( "Down_Moving" );
    }

    public void PlayUpSleep( )
    {
        animator.Play( "Up_Sleep" );
    }
    public void PlayUpWakeUp( )
    {
        animator.Play( "Up_WakeUp" );
    }
    public void PlayUpMoving( )
    {
        animator.Play( "Up_Moving" );
    }

    public void PlayHitWall( )
    {
        animator.Play( "Hit_Wall" );
    }
}
