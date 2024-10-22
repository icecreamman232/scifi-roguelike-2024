using System;
using UnityEngine;

namespace SGGames.Scripts.ScriptableEvent
{
    [CreateAssetMenu(menuName = "SGGames/Scriptable Event/Player Health Event")]
    public class PlayerHealthEvent : ScriptableObject
    {
        protected Action<float,float> m_listeners;
    
        public void AddListener(Action<float,float> addListener)
        {
            m_listeners += addListener;
        }

        public void RemoveListener(Action<float,float> removeListener)
        {
            m_listeners -= removeListener;
        }

        public void Raise(float cur, float max)
        {
            m_listeners?.Invoke(cur,max);
        }
    } 
}