using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    public GonzoMovement.MoveDirection moveDirection;
    
    public GonzoMovement.MoveDirection GetDirection( )
    {
        return moveDirection;
    }
}
