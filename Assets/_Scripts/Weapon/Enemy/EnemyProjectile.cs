using System;
using SGGames.Scripts.Data;
using UnityEngine;

namespace SGGames.Scripts.Weapons
{
    public class EnemyProjectile : Projectile
    {
        [SerializeField] protected EnemyBulletData m_bulletData;

        private void Start()
        {
            m_speed = m_bulletData.BulletSpeed;
            m_range = m_bulletData.BulletRange;
        }
    }
}

