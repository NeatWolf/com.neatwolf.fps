using UnityEngine;

namespace NeatWolf.FPS
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private PlayerInputHandler inputHandler;

        [SerializeField]
        private CharacterController controller;

        [SerializeField]
        private float moveSpeed = 5f;

        [SerializeField]
        private float gravity = -9.81f;

        [SerializeField]
        private AnimationCurve accelerationCurve = AnimationCurve.Linear(0, 0, 1, 1);

        [SerializeField]
        private float accelerationTime = 0.2f;

        private Vector2 currentSpeed;
        private Vector3 verticalVelocity;

        void Update()
        {
            Move();
        }

        void Move()
        {
            Vector2 targetSpeed = new Vector2(inputHandler.GetMove().x, inputHandler.GetMove().y) * moveSpeed;
            currentSpeed = Vector2.Lerp(currentSpeed, targetSpeed, accelerationCurve.Evaluate(Time.deltaTime / accelerationTime));
            Vector3 moveDirection = transform.forward * currentSpeed.y + transform.right * currentSpeed.x;

            if (controller.isGrounded && verticalVelocity.y < 0)
            {
                verticalVelocity.y = -2f; // Small downward force when grounded to keep the player grounded
            }
            else
            {
                // Only apply gravity if player is not grounded
                verticalVelocity.y += gravity * Time.deltaTime;
            }

            moveDirection.y = verticalVelocity.y;
            controller.Move(moveDirection * Time.deltaTime);
        }
    }
}