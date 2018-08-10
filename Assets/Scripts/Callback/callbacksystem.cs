using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DirectCallbacks{

    public class callbacksystem : MonoBehaviour{
        void Start()
        {
            EventManager.current.RegisterListener(EventManager.EVENT_TYPE.GamePause,stop);
        }

        void stop(EventInfo e)
        {
            UnitMove unitmove = (UnitMove)e;
            Debug.Log("I'm stopped!");
        }
    }

}