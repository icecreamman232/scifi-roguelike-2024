using UnityEngine;

namespace SGGames.Scripts.Characters
{
    /// <summary>
    /// Base class for all character behavior: shoot, dash, etc..
    /// </summary>
    public class CharacterBehavior : MonoBehaviour
    {
        [Header("Base Params")]
        [SerializeField] protected bool m_isAllow;
        
        public bool IsAllow => m_isAllow;
        
        public void ToggleAllow(bool toggle)
        {
            m_isAllow = toggle;
        }

        protected virtual void HandleInput()
        {
            
        }

        protected virtual void UpdateAnimator()
        {
            
        }

        protected virtual void Update()
        {
            if (!m_isAllow) return;
            
            HandleInput();
            UpdateAnimator();
        }
    }
}

