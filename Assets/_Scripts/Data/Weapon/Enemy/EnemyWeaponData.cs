using UnityEngine;

namespace SGGames.Scripts.Data
{
    [CreateAssetMenu(menuName = "SGGames/Data/Enemy Weapon",fileName = "_EnemyWeaponData")]
    public class EnemyWeaponData : ScriptableObject
    {
        public float DelayBetweenShots;
    }
}

