using SGGames.Scripts.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SGGames.Scripts.Healths
{
    public class DamageHandler : MonoBehaviour
    {
        [SerializeField] protected float m_minDamage;
        [SerializeField] protected float m_maxDamage;
        [SerializeField] protected float m_invulnerableDuration;
        [SerializeField] protected LayerMask m_targetLayer;

        public virtual void SetDamage(float min, float max)
        {
            m_minDamage = min;
            m_maxDamage = max;
        }

        protected virtual float GetDamage()
        {
            return Random.Range(m_minDamage, m_maxDamage);
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (!LayerManager.IsInLayerMask(other.gameObject.layer, m_targetLayer)) return;

            CauseDamage(other.gameObject);
        }

        protected virtual void CauseDamage(GameObject target)
        {
            var health = target.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(GetDamage(),m_invulnerableDuration,this.gameObject);
            }
        }
    }
}

