
using System;
using UnityEngine;

namespace SGGames.Scripts.Enemy
{
    public class BrainDecisionDetectTargetInCircle : BrainDecision
    {
        [SerializeField] private LayerMask m_targetLayer;
        [SerializeField] private float m_radius;
        
        public override bool CheckDecision()
        {
            var hit =Physics2D.OverlapCircle(transform.position, m_radius, m_targetLayer);
            if (hit != null)
            {
                m_brain.Target = hit.transform;
                return true;
            }
            m_brain.Target = null;
            return false;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, m_radius);
        }
    }
}

