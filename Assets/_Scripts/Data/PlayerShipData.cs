using UnityEngine;

namespace SGGames.Scripts.Data
{
    public enum PlayerShipID
    {
        BlueShip,
    }
    
    
    [CreateAssetMenu(fileName = "PlayerShipData", menuName = "SGGames/Player Ship Data")]
    public class PlayerShipData : ScriptableObject
    {
        [SerializeField] private PlayerShipID m_shipID;
        [SerializeField] private float m_moveSpeed;
        
        public PlayerShipID ShipID => m_shipID;
        public float MoveSpeed => m_moveSpeed;
    }   
}

