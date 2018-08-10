using UnityEngine;
using System.Collections;

namespace DirectCallbacks
{
    public abstract class EventInfo
    {
        public string EventDescription;
    }

    public class DebugEventInfo : EventInfo
    {
        public int verbositylevel;
    }
    public class UnitMove : EventInfo
    {
        public GameObject unit;
    }
}