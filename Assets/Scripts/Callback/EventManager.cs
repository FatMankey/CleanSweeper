using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DirectCallbacks
{
    public class EventManager : MonoBehaviour
    {
        static EventManager _current;

        static public EventManager current
        {
            get
            {
                if (_current == null)
                {
                    _current = FindObjectOfType<EventManager>();

                }

                return _current;
            }
        }
        public delegate void EventListener(EventInfo e);
        public enum EVENT_TYPE
        {
            PieceConnect, Gameover, GamePause, MoveUp, MoveRight,MoveLeft,MoveDown         
        }

        private Dictionary<EVENT_TYPE, List<EventListener>> eventlisteners;
        // Use this for initialization
        void Start()
        {

        }

        public void RegisterListener(EVENT_TYPE eventType, EventListener Listener)
        {
            if (eventlisteners == null)
            {
                eventlisteners = new Dictionary<EVENT_TYPE,List<EventListener>>();
            }

            if (eventlisteners[eventType] == null)
            {
                eventlisteners[eventType] = new List<EventListener>();
            }
            eventlisteners[eventType].Add(Listener);
        }

        public void unRegisterListener(EVENT_TYPE eventType, EventListener listener)
        {

        }

        public void fireEvent(EVENT_TYPE eventType, EventInfo eventInfo)
        {
            if (eventlisteners == null || eventlisteners[eventType] == null)
            {
                //no is there;
                return;

            }

            foreach (EventListener el in eventlisteners[eventType] )
            {
                el(eventInfo);
            }
        }
    }
}