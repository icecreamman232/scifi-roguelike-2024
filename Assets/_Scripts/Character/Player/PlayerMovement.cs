using SGGames.Scripts.Characters;
using SGGames.Scripts.Data;
using UnityEngine;

namespace SGGames.Scripts.Character
{
    public class PlayerMovement : CharacterBehavior
    {
        [Header("Movement")] 
        [SerializeField] private PlayerInputSetting m_inputSetting;
        [SerializeField] private PlayerShipData m_shipData;
        [SerializeField] private Vector2 m_movementDirection;
        [SerializeField] private Transform m_modelTransform; 
        [SerializeField] private Vector2 m_worldLimit;
        
        private float m_currentSpeed;
        private Vector2 m_rotationVec;
        private float m_rotateAngle;
        private Camera m_camera;
        private Vector3 m_lastPosition;
        

        private void Start()
        {
            m_camera = Camera.main;
            m_currentSpeed = m_shipData.MoveSpeed;
        }

        protected override void HandleInput()
        {
            m_movementDirection = Vector2.zero;
            
            if (Input.GetKey(m_inputSetting.GetPlayerInput(PlayerButtonAction.MOVE_LEFT)))
            {
                m_movementDirection.x = -1;
            }
            if (Input.GetKey(m_inputSetting.GetPlayerInput(PlayerButtonAction.MOVE_RIGHT)))
            {
                m_movementDirection.x = 1;
            }
            if (Input.GetKey(m_inputSetting.GetPlayerInput(PlayerButtonAction.MOVE_UP)))
            {
                m_movementDirection.y = 1;
            }
            if (Input.GetKey(m_inputSetting.GetPlayerInput(PlayerButtonAction.MOVE_DOWN)))
            {
                m_movementDirection.y = -1;
            }
            
            base.HandleInput();
        }

        protected override void Update()
        {
            if (!m_isAllow) return;
            
            HandleInput();
            UpdateMovement();
            UpdateRotation();
            UpdateAnimator();
        }

        private void UpdateMovement()
        {
            transform.Translate(m_movementDirection * (m_currentSpeed * Time.deltaTime));
            CheckMovementLimit();
        }

        private void CheckMovementLimit()
        {
            m_lastPosition = transform.position;
            if (m_lastPosition.y > m_worldLimit.y)
            {
                m_lastPosition.y = m_worldLimit.y;
            }

            if (m_lastPosition.y < -m_worldLimit.y)
            {
                m_lastPosition.y = -m_worldLimit.y;
            }

            if (m_lastPosition.x > m_worldLimit.x)
            {
                m_lastPosition.x = m_worldLimit.x;
            }
            
            if (m_lastPosition.x < -m_worldLimit.x)
            {
                m_lastPosition.x = -m_worldLimit.x;
            }
            
            transform.position = m_lastPosition;
        }

        private void UpdateRotation()
        {
            m_rotationVec = (GetWorldMousePos() - transform.position).normalized;
            //player sprite is look up so offset angle is 90
            m_rotateAngle = Mathf.Atan2(m_rotationVec.y, m_rotationVec.x) * Mathf.Rad2Deg - 90f; 
            m_modelTransform.rotation = Quaternion.AngleAxis(m_rotateAngle,Vector3.forward);
        }
        
        private Vector3 GetWorldMousePos()
        {
            var pos = m_camera.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            return pos;
        }
    }
}
