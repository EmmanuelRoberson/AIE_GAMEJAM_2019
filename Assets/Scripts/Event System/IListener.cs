using UnityEngine;

namespace Event_System
{
    public interface IListener
    {
        void Invoke(Object sender);
    }
}
