using System.Collections;
using SGGames.Scripts.Characters;
using SGGames.Scripts.Healths;
using UnityEngine;

namespace SGGames.Scripts.Enemy
{
    public class OctopusChangeSkin : CharacterBehavior
    {
        [SerializeField] private float m_hardSkinDuration;
        [SerializeField] private Sprite m_normalSprite;
        [SerializeField] private Sprite m_hardSprite;
        [SerializeField] private SpriteRenderer m_SpriteRenderer;
        [SerializeField] private EnemyHealth m_enemyHealth;
        private bool m_isHardSkin;

        private void Start()
        {
            m_enemyHealth.OnHit += OnGettingHit;
        }

        private void OnDestroy()
        {
            m_enemyHealth.OnHit -= OnGettingHit;
        }

        private void OnGettingHit()
        {
            if (m_isHardSkin) return;
            StartCoroutine(OnBeingHardSkin());
        }

        private IEnumerator OnBeingHardSkin()
        {
            ChangeToHardSkin();
            yield return new WaitForSeconds(m_hardSkinDuration);
            ChangeToNormalSkin();
        }

        private void ChangeToHardSkin()
        {
            m_isHardSkin = true;
            m_enemyHealth.EnableImmuneToDamage();
            m_SpriteRenderer.sprite = m_hardSprite;
        }

        private void ChangeToNormalSkin()
        {
            m_isHardSkin = false;
            m_enemyHealth.DisableImmuneToDamage();
            m_SpriteRenderer.sprite = m_normalSprite;
        }
    }
}

