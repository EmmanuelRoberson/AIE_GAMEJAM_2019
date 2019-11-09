using System.Collections.Generic;
using UnityEngine;

namespace Event_System
{
    [CreateAssetMenu(menuName = "Event")]
    public class Event : ScriptableObject
    {
        private List<IListener> listeners = new List<IListener>();
        public void AddListener(IListener newListener)
        {
            listeners.Add(newListener);
        }
        public void Raise(GameObject sender)
        {
            foreach(IListener listener in listeners)
            {
                listener.Invoke(sender);
            }
        }
        public void Raise()
        {
            foreach (IListener listener in listeners)
            {
                listener.Invoke(null);
            }
        }
    }
}