using System;
using UnityEngine;

namespace SGGames.Scripts.Data
{

    public enum PlayerButtonAction
    {
        MOVE_LEFT,
        MOVE_RIGHT,
        MOVE_UP,
        MOVE_DOWN,
    }
    
    [CreateAssetMenu(fileName = "PlayerInputSetting", menuName = "SGGames/Player Input Setting")]
    public class PlayerInputSetting : ScriptableObject
    {
        [SerializeField] protected PlayerInput[] m_PlayerInputs;

        public KeyCode GetPlayerInput(PlayerButtonAction playerButtonAction)
        {
            return m_PlayerInputs[(int)playerButtonAction].KeyCode;
        }
    }

    [Serializable]
    public struct PlayerInput
    {
        public PlayerButtonAction ButtonAction;
        public KeyCode KeyCode;
    }
}
