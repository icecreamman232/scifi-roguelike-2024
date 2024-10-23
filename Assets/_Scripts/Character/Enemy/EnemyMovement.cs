using SGGames.Scripts.Characters;
using UnityEngine;

namespace SGGames.Scripts.Enemy
{
    public class EnemyMovement : CharacterBehavior
    {
        [SerializeField] private float m_moveSpeed;
        [SerializeField] private Vector2 m_movementDirection;
        [SerializeField] private Vector2 m_moveLimit;
        private Vector3 m_lastPosition;

        public virtual void SetMovementDirection(Vector2 newDirection)
        {
            m_movementDirection = newDirection;
        }

        public void StopMoving()
        {
            m_isAllow = false;
        }

        public void StartMoving()
        {
            m_isAllow = true;
        }

        protected override void Update()
        {
            if (!m_isAllow) return;
            
            UpdateMovement();
        }

        private void UpdateMovement()
        {
            transform.Translate(m_movementDirection * (m_moveSpeed * Time.deltaTime));
            CheckLimit();
        }

        private void CheckLimit()
        {
            m_lastPosition = transform.position;
            if (m_lastPosition.y > m_moveLimit.y)
            {
                m_lastPosition.y = m_moveLimit.y;
            }

            if (m_lastPosition.y < -m_moveLimit.y)
            {
                m_lastPosition.y = -m_moveLimit.y;
            }

            if (m_lastPosition.x > m_moveLimit.x)
            {
                m_lastPosition.x = m_moveLimit.x;
            }
            
            if (m_lastPosition.x < -m_moveLimit.x)
            {
                m_lastPosition.x = -m_moveLimit.x;
            }
            
            transform.position = m_lastPosition;
        }
    }
}

