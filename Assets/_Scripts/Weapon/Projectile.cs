using System.Collections;
using SGGames.Scripts.Healths;
using SGGames.Scripts.Scripts.Common;
using UnityEngine;

namespace SGGames.Scripts.Weapons
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] protected Transform m_model;
        [SerializeField] protected float m_speed;
        [SerializeField] protected Vector2 m_direction;
        [Header("Range")]
        [SerializeField] protected bool m_destroyIfMaxRange;
        [SerializeField] protected float m_range;
        [Header("Damage")]
        [SerializeField] protected bool m_destroyIfDamage;
        [SerializeField] protected float m_delayBeforeDestroyByDamage;
        [SerializeField] protected DamageHandler m_damageHandler;
        [SerializeField] protected AnimationParameter m_destroyAnim;

        protected bool m_isAlive;
        protected Vector2 m_initPos;
        protected float m_traveledDistance;
        
        
        protected virtual void OnEnable()
        {
            if (m_destroyIfDamage)
            {
                m_damageHandler.OnHitDamagable += OnGettingHit;
            }
        }

        protected virtual void OnDisable()
        {
            if (m_destroyIfDamage)
            {
                m_damageHandler.OnHitDamagable -= OnGettingHit;
            }
        }

        protected virtual void OnGettingHit()
        {
            if (!m_isAlive) return;
            m_isAlive = false;
            m_model.gameObject.SetActive(false);
            StartCoroutine(OnDelayBeforeDestroyByGettingHit());
        }

        protected virtual IEnumerator OnDelayBeforeDestroyByGettingHit()
        {
            m_destroyAnim.SetTrigger();
            yield return new WaitForSeconds(m_delayBeforeDestroyByDamage);
            DestroySelf();
        }

        public virtual void WakeUp(Vector2 spawnPos,Vector2 direction, Quaternion rotation = default)
        {
            transform.position = spawnPos;
            m_initPos = spawnPos;
            m_direction = direction;
            m_model.gameObject.SetActive(true);
            m_model.rotation = rotation;
            m_traveledDistance = 0;
            m_isAlive = true;
        }

        protected virtual void Update()
        {
            if (!m_isAlive) return;
            UpdateMovement();
            if (m_destroyIfMaxRange)
            {
                CheckRange();
            }
        }

        protected virtual void UpdateMovement()
        {
            transform.Translate(m_direction * (m_speed * Time.deltaTime));
        }

        protected virtual void CheckRange()
        {
            m_traveledDistance = Vector2.Distance(m_initPos, transform.position);
            if(m_traveledDistance >= m_range)
            {
                m_isAlive = false;
                DestroySelf();
            }
        }
        
        public virtual void DestroySelf()
        {
            this.gameObject.SetActive(false);
        }
    }
}
