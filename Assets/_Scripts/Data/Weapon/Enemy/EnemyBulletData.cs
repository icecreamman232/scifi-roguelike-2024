using UnityEngine;

namespace SGGames.Scripts.Data
{
    [CreateAssetMenu(menuName = "SGGames/Data/Enemy Bullet",fileName = "EnemyBulletData")]
    public class EnemyBulletData : ScriptableObject
    {
        public float BulletSpeed;
        public float BulletRange;
    }
}

