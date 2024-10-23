using SGGames.Scripts.Character;
using UnityEngine;

namespace SGGames.Scripts.Weapons
{
    public class PlayerBlasterGun : RangedWeapon
    {
        [SerializeField] private PlayerMovement m_playerMovement;
        protected override void SpawnBullet()
        {
            var bulletGO = m_bulletPooler.GetPooledGameObject();
            var projectile = bulletGO.GetComponent<Projectile>();
            projectile.WakeUp(m_shootPivot.position,m_playerMovement.BodyRotationDirection,m_playerMovement.BodyRotation);
        }
    }

}
