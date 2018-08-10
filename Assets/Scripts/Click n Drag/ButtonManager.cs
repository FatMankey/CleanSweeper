using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GonzoMovement gonzoMovement;
    public Arrow[] arrows;
    public GameObject GoButton;
    public GameObject ResetButton;

    public void OnStart( )
    {
        GoButton.SetActive( false );
        ResetButton.SetActive( true );
        gonzoMovement.OnStart( );
    }

    public void OnReset( )
    {
        for( int i = 0; i < arrows.Length; i++ )
        {
            arrows[i].Reset( );
        }
        gonzoMovement.Reset( );
        ResetButton.SetActive( false );
        GoButton.SetActive( true );
    }
}
