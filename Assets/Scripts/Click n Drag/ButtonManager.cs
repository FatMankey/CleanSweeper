using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GonzoMovement[] gonzoMovement;
    [System.Serializable]
    public class CustomArrows
    {
        public string name = "";
        public Arrow arrow;
        public int numberOfArrows = 0;
    }
    public CustomArrows[] Arrows;
    public GameObject GoButton;
    public GameObject ResetButton;
    public GameObject WinnerBanner;

    private LevelManager lMan;
    private int roombaCounter = 0;

    void OnEnable( )
    {
        lMan = FindObjectOfType<LevelManager>( );
        ResetButton.SetActive( false );
        GoButton.SetActive( true );
        roombaCounter = 0;
        for( int i = 0; i < 4; i++ )
        {
            Arrows[i].arrow.OnInit( Arrows[i].numberOfArrows );
        }
        for( int i = 0; i < gonzoMovement.Length; i++ )
        {
            gonzoMovement[i].OnInit( );
        }
    }

    public void OnGoButton( )
    {
        for( int i = 0; i < gonzoMovement.Length; i++ )
        {
            gonzoMovement[i].OnStart( );
        }
        GoButton.SetActive( false );
        ResetButton.SetActive( true );
    }

    public void OnResetButton( )
    {
        for( int i = 0; i < Arrows.Length; i++ )
        {
            Arrows[i].arrow.Reset( );
        }
        for( int i = 0; i < gonzoMovement.Length; i++ )
        {
            gonzoMovement[i].Reset( );
        }
        ResetButton.SetActive( false );
        GoButton.SetActive( true );
    }

    public void OnEnterGoal( )
    {
        roombaCounter++;
        if( roombaCounter >= gonzoMovement.Length )
        {
            StartCoroutine( StartGameWon( ) );
        }
    }
    
    IEnumerator StartGameWon( )
    {
        WinnerBanner.SetActive( true );
        yield return new WaitForSeconds( 3.0f );
        WinnerBanner.SetActive( false );
        lMan.OnNextLevel( );
    }
}
