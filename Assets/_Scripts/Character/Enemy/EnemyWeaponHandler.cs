using System;
using SGGames.Scripts.Characters;
using SGGames.Scripts.Weapons;
using UnityEngine;

namespace SGGames.Scripts.Enemy
{
    public class EnemyWeaponHandler : CharacterBehavior
    {
        [SerializeField] protected EnemyRangedWeapon m_rangedWeapon;
        protected EnemyController m_controller;

        private void Start()
        {
            m_controller = GetComponent<EnemyController>();
        }


        public void ShootAtBrainTarget()
        {
            if (m_controller.CurrentBrain.Target == null) return;
            
            m_rangedWeapon.ShootAt(m_controller.CurrentBrain.Target.transform.position);
        }
    }
}

