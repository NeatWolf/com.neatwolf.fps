using UnityEngine;

namespace NeatWolf.FPS
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        float speed = 6f;

        [SerializeField]
        float jumpHeight = 3f;

        [SerializeField]
        float gravity = -9.81f;

        Vector3 velocity;
        bool isJumping;
        CharacterController controller;
        PlayerInputHandler inputHandler;

        void Awake()
        {
            controller = GetComponent<CharacterController>();
            inputHandler = GetComponent<PlayerInputHandler>();
        }

        void Update()
        {
            Move();
            Jump();
            ApplyGravity();
        }

        void Move()
        {
            Vector2 direction = inputHandler.GetMove();
            Vector3 move = transform.right * direction.x + transform.forward * direction.y;
            controller.Move(move * (speed * Time.deltaTime));
        }

        void Jump()
        {
            if (controller.isGrounded && isJumping)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                isJumping = false;
            }
        }

        void ApplyGravity()
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        public void OnJump()
        {
            isJumping = true;
        }
    }
}