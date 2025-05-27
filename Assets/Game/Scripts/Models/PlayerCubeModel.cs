using Enum;
using Saves;
using UnityEngine;

namespace Models
{
    public class PlayerCubeModel : MonoBehaviour
    {
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Transform groundCheck;

        [SerializeField] private float baseSpeed;
        [SerializeField] private float baseJumpForce;
        [SerializeField] private float groundCheckRadius;

        private Transform _cameraTransform;

        private bool _isGrounded;

        private float _moveSpeed;
        private float _jumpForce;

        private void Update()
        {
            HandleJump();
        }

        private void FixedUpdate()
        {
            HandleMovement();
        }

        public void Setup()
        {
            _cameraTransform = Camera.main.transform;
            SetupStats();
        }
        
        public void SetupStats()
        {
            _moveSpeed = baseSpeed + GameSaves.Instance.GetCharacteristicValue(CharacteristicType.Speed);
            _jumpForce = baseJumpForce + GameSaves.Instance.GetCharacteristicValue(CharacteristicType.JumpForce);
        }

        private void HandleMovement()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 forward = _cameraTransform.forward;
            Vector3 right = _cameraTransform.right;

            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();

            Vector3 moveDirection = forward * moveZ + right * moveX;
            Vector3 move = moveDirection * _moveSpeed;

            Vector3 velocity = rb.velocity;
            velocity.x = move.x;
            velocity.z = move.z;
            rb.velocity = velocity;
        }

        private void HandleJump()
        {
            _isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
        }
    }
}
