using SGGames.Scripts.Data;
using SGGames.Scripts.ScriptableEvent;
using UnityEngine;

namespace SGGames.Scripts.Healths
{
    public class PlayerHealth : Health
    {
        [SerializeField] private PlayerShipData m_shipData;
        [SerializeField] private PlayerHealthEvent m_healthBarEvent;
        private void Start()
        {
            m_maxHealth = m_shipData.InitialHealth;
            m_currentHealth = m_maxHealth;
            UpdateHealthBar();
        }

        protected override void UpdateHealthBar()
        {
            m_healthBarEvent.Raise(m_currentHealth,m_maxHealth);
            base.UpdateHealthBar();
        }
    }
}

