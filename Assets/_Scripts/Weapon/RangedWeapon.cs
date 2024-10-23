using SGGames.Scripts.Managers;
using UnityEngine;

namespace SGGames.Scripts.Weapons
{
    public class RangedWeapon : Weapon
    {
        [SerializeField] protected Transform m_shootPivot;
        [SerializeField] protected ObjectPooler m_bulletPooler;
        [SerializeField] protected float m_delayBetween2Shots;
        
        protected bool m_isDelayBetween2Shots;
        protected float m_delayTimer;
        
        public virtual void StartShooting()
        {
            //Cant shoot
            if (m_isDelayBetween2Shots) return;
            
            m_isDelayBetween2Shots = true;
            m_delayTimer = m_delayBetween2Shots;

            SpawnBullet();
        }

        public virtual void StopShooting()
        {
            m_isDelayBetween2Shots = false;
            m_delayTimer = 0;
        }

        protected virtual void SpawnBullet()
        {
            var bulletGO = m_bulletPooler.GetPooledGameObject();
            var projectile = bulletGO.GetComponent<Projectile>();
            projectile.WakeUp(m_shootPivot.position, Vector2.up);
        }
        

        protected virtual void Update()
        {
            if (m_isDelayBetween2Shots)
            {
                UpdateDelayBetween2Shots();
            }
        }

        protected virtual void UpdateDelayBetween2Shots()
        {
            m_delayTimer -= Time.deltaTime;
            if (m_delayTimer <= 0)
            {
                m_delayTimer = 0;
                m_isDelayBetween2Shots = false;
            }
        }
    }
}

