using SGGames.Scripts.Characters;
using UnityEngine;

namespace SGGames.Scripts.Enemy
{
    public class EnemyController : CharacterBehavior
    {
        [SerializeField] private EnemyBrain m_initBrain;
        [SerializeField] private EnemyBrain m_currentBrain;

        private void Start()
        {
            m_initBrain.Owner = this;
            SetActiveBrain(m_initBrain);
        }
        
        public void SetActiveBrain(EnemyBrain brainToSwap)
        {
            m_currentBrain = brainToSwap;
            m_currentBrain.BrainActive = true;
        }
    }
}

