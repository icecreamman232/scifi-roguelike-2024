using System;
using SGGames.Scripts.Data;
using UnityEngine;

namespace SGGames.Scripts.Weapons
{
    public class EnemyRangedWeapon : RangedWeapon
    {
        [SerializeField] private EnemyWeaponData m_weaponData;

        private void Start()
        {
            m_delayBetween2Shots = m_weaponData.DelayBetweenShots;
        }

        public virtual void ShootAt(Vector3 position)
        {
            var shootDir = (position - transform.position).normalized;
            
            if (m_isDelayBetween2Shots) return;
            
            m_isDelayBetween2Shots = true;
            m_delayTimer = m_delayBetween2Shots;

            SpawnBullet(shootDir);
        }

        protected virtual void SpawnBullet(Vector2 direction)
        {
            var bulletGO = m_bulletPooler.GetPooledGameObject();
            var projectile = bulletGO.GetComponent<Projectile>();
            projectile.WakeUp(m_shootPivot.position, direction);
        }
    }
}

