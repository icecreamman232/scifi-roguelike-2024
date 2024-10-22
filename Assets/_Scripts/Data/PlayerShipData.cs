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
        [SerializeField] private float m_initialHealth;
        
        public PlayerShipID ShipID => m_shipID;
        public float InitialHealth => m_initialHealth;
        public float MoveSpeed => m_moveSpeed;
        
    }   
}

