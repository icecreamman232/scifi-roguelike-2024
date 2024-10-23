using UnityEngine;

namespace SGGames.Scripts.Weapons
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] protected Transform m_model;
        [SerializeField] protected float m_speed;
        [SerializeField] protected Vector2 m_direction;
        [Header("Range")]
        [SerializeField] protected bool m_destroyIfMaxRange;
        [SerializeField] protected float m_range;
        
        protected bool m_isAlive;
        protected Vector2 m_initPos;
        protected float m_traveledDistance;
        
        public virtual void WakeUp(Vector2 spawnPos,Vector2 direction, Quaternion rotation = default)
        {
            transform.position = spawnPos;
            m_initPos = spawnPos;
            m_direction = direction;
            m_model.rotation = rotation;
            m_traveledDistance = 0;
            m_isAlive = true;
        }

        protected virtual void Update()
        {
            if (!m_isAlive) return;
            UpdateMovement();
            if (m_destroyIfMaxRange)
            {
                CheckRange();
            }
        }

        protected virtual void UpdateMovement()
        {
            transform.Translate(m_direction * (m_speed * Time.deltaTime));
        }

        protected virtual void CheckRange()
        {
            m_traveledDistance = Vector2.Distance(m_initPos, transform.position);
            if(m_traveledDistance >= m_range)
            {
                DestroySelf();
            }
        }
        
        public virtual void DestroySelf()
        {
            this.gameObject.SetActive(false);
        }
    }
}
