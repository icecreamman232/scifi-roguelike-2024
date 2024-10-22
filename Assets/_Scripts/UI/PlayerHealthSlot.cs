using System;
using UnityEngine;
using UnityEngine.UI;

namespace SGGames.Scripts.UI
{
    public enum HealthSlotState
    {
        FULL,
        EMPTY,
    }
    public class PlayerHealthSlot : MonoBehaviour
    {
        [SerializeField] private Sprite m_fullSprite;
        [SerializeField] private Sprite m_emptySprite;
        [SerializeField] private Image m_icon;

        public void SetState(HealthSlotState newState)
        {
            switch (newState)
            {
                case HealthSlotState.FULL:
                    OnFullState();
                    break;
                case HealthSlotState.EMPTY:
                    OnEmptyState();
                    break;
            }
        }

        private void OnFullState()
        {
            m_icon.sprite = m_fullSprite;
        }

        private void OnEmptyState()
        {
            m_icon.sprite = m_emptySprite;
        }
    }
}

