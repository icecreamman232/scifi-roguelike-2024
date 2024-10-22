using SGGames.Scripts.ScriptableEvent;
using UnityEngine;

namespace SGGames.Scripts.UI
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [SerializeField] private CanvasGroup m_canvasGroup;
        [SerializeField] private PlayerHealthEvent m_playerHealthEvent;
        [SerializeField] private PlayerHealthSlot[] m_healthSlots;

        private void Awake()
        {
            m_playerHealthEvent.AddListener(OnUpdateHealthBar);
        }

        private void OnDestroy()
        {
            m_playerHealthEvent.RemoveListener(OnUpdateHealthBar);
        }

        private void Start()
        {
            ShowHealthBar();
        }
        
        private void OnUpdateHealthBar(float cur, float max)
        {
            for (int i = 0; i < m_healthSlots.Length; i++)
            {
                m_healthSlots[i].SetState(i >= cur ? HealthSlotState.EMPTY : HealthSlotState.FULL);
            }
        }
        
        private void ShowHealthBar()
        {
            m_canvasGroup.alpha = 1;
        }

        private void HideHealthBar()
        {
            m_canvasGroup.alpha = 0;
        }
    }
}

