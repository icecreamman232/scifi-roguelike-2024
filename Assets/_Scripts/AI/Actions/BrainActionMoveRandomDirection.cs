using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SGGames.Scripts.Enemy
{
    public class BrainActionMoveRandomDirection : BrainAction
    {
        [SerializeField] private EnemyMovement m_enemyMovement;
        
        public override void DoAction()
        {
            m_enemyMovement.SetMovementDirection(Random.insideUnitCircle);
        }
    }
}

