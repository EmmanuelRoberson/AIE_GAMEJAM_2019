using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Event_System
{
    delegate void Actions();
    public class EventListener : MonoBehaviour,IListener
    {
        [SerializeField]
        UnityEvent actions;
        [SerializeField]
        Event Event;
        [SerializeField]
        GameObject intendedSender;
        // Use this for initialization
        void Start()
        {
            Event.AddListener(this);
        }

        public void Invoke(Object Sender)
        {
            if(intendedSender == null)
            {
                actions.Invoke();
                return;
            }
            else if(intendedSender == Sender)
            {
                actions.Invoke();
                return;
            }
        }
    }
}