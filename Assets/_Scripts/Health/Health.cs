
using System;
using System.Collections;
using UnityEngine;

namespace SGGames.Scripts.Healths
{
    /// <summary>
    ///Base class for all health behavior
    /// </summary>
    public class Health : MonoBehaviour
    {
        [SerializeField] protected float m_currentHealth;
        [SerializeField] protected float m_maxHealth;
        [SerializeField] protected bool m_isInvulnerable;

        public Action OnHit;
        
        public virtual void TakeDamage(float damage,float invulnerableDuration, GameObject source)
        {
            if (m_isInvulnerable) return;
            
            m_currentHealth -= damage;
            OnHit?.Invoke();
            UpdateHealthBar();
            
            if (m_currentHealth <= 0)
            {
                Kill();
            }
            else
            {
                StartCoroutine(OnInvulnerability(invulnerableDuration));
            }
        }

        protected virtual void UpdateHealthBar()
        {
            
        }

        protected virtual IEnumerator OnInvulnerability(float duration)
        {
            m_isInvulnerable = true;
            yield return new WaitForSeconds(duration);
            m_isInvulnerable = false;
        }

        protected virtual void Kill()
        {
            this.gameObject.SetActive(false);
        }
    }
}

