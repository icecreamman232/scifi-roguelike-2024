using UnityEditor;
using UnityEngine;

namespace SGGames.Scripts.Data
{
    [CreateAssetMenu(menuName = "SGGames/Data/Enemy Data Container",fileName = "_EnemyDataContainer")]
    public class EnemyDataContainer : ScriptableObject
    {
        public string EnemyID;
        public EnemyBulletData BulletData;
        public EnemyWeaponData WeaponData;

        public void UpdateBulletData(float speed, float range)
        {
            BulletData.BulletSpeed = speed;
            BulletData.BulletRange = range;
            EditorUtility.SetDirty(BulletData);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        public void UpdateWeaponData(float delayBetweenShots)
        {
            WeaponData.DelayBetweenShots = delayBetweenShots;
            EditorUtility.SetDirty(WeaponData);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}

