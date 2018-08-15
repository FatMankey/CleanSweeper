using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject LoadingFrame;
    public GameObject[] Levels;
    public int currentLevelCounter;

    private GameObject _currentTempLevel;

    void Start( )
    {
        OnNextLevel( );
    }

    public void OnNextLevel( )
    {
        StartCoroutine( StartNextLevel( ) );
    }

    IEnumerator StartNextLevel( )
    {
        LoadingFrame.SetActive( true );

        if( _currentTempLevel != null )
        {
            Destroy( _currentTempLevel );
        }
        yield return new WaitForSeconds( 1.0f );
        LoadingFrame.SetActive( false );
        _currentTempLevel = Instantiate( Levels[currentLevelCounter] );
        currentLevelCounter = currentLevelCounter < Levels.Length - 1 ? currentLevelCounter + 1 : 0;
    }
}
