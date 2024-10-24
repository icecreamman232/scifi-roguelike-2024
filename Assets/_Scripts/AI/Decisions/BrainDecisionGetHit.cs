using SGGames.Scripts.Healths;
using UnityEngine;

namespace SGGames.Scripts.Enemy
{
    public class BrainDecisionGetHit : BrainDecision
    {
        [SerializeField] private EnemyHealth m_enemyHealth;
        [SerializeField] private bool m_isHit;
        private void OnEnable()
        {
            m_enemyHealth.OnHit += OnGettingHit;
        }

        private void OnDisable()
        {
            m_enemyHealth.OnHit -= OnGettingHit;
        }

        private void OnGettingHit()
        {
            m_isHit = true;
        }

        public override bool CheckDecision()
        {
            return m_isHit;
        }

        public override void OnExitState()
        {
            m_isHit = false;
            base.OnExitState();
        }
    }
}
