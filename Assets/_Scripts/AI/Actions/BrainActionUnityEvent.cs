using UnityEngine;
using UnityEngine.Events;

namespace SGGames.Scripts.Enemy
{
    public class BrainActionUnityEvent : BrainAction
    {
        [SerializeField] private UnityEvent m_event;
        
        public override void DoAction()
        {
            m_event?.Invoke();
        }
    }
}

