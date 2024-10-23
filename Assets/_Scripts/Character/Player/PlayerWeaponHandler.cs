

using SGGames.Scripts.Weapons;
using UnityEngine;

namespace SGGames.Scripts.Characters
{
    public class PlayerWeaponHandler : CharacterBehavior
    {
        [SerializeField] private RangedWeapon m_rangedWeapon;
        
        protected override void HandleInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_rangedWeapon.StartShooting();
            }
            base.HandleInput();
        }
    }
}

