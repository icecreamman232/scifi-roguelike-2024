using UnityEngine;

namespace SGGames.Scripts.Healths
{
    public class EnemyHealth : Health
    {
        [SerializeField] protected bool m_immuneToDamage;

        public void EnableImmuneToDamage()
        {
            m_immuneToDamage = true;
        }

        public void DisableImmuneToDamage()
        {
            m_immuneToDamage = false;
        }

        public override void TakeDamage(float damage, float invulnerableDuration, GameObject source)
        {
            if (m_immuneToDamage) return;
            base.TakeDamage(damage, invulnerableDuration, source);
        }
    }
}

