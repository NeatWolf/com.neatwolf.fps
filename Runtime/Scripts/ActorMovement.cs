// ActorMovement.cs
using UnityEngine;

namespace NeatWolf.FPS
{
    public class ActorMovement : ActorBehaviour
    {
        [SerializeField]
        private CharacterController controller;

        private Vector2 currentSpeed;
        private Vector3 verticalVelocity;
        private const float gravity = -9.81f;

        protected override void OnActorAwake()
        {
            base.OnActorAwake();
            // No additional setup code required as of now.
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector2 targetSpeed = new Vector2(actor.inputHandler.GetMove().x, actor.inputHandler.GetMove().y) * actor.properties.baseMovementSpeed;
            currentSpeed = Vector2.Lerp(currentSpeed, targetSpeed, actor.properties.movementAccelerationCurve.Evaluate(Time.deltaTime / actor.properties.movementAccelerationTime));
            Vector3 moveDirection = transform.forward * currentSpeed.y + transform.right * currentSpeed.x;

            if (controller.isGrounded && verticalVelocity.y < 0)
            {
                verticalVelocity.y = -2f; // Small downward force when grounded to keep the player grounded
            }
            else
            {
                // Only apply gravity if actor is not grounded
                verticalVelocity.y += gravity * actor.properties.gravityInfluence * Time.deltaTime;
            }

            moveDirection.y = verticalVelocity.y;
            controller.Move(moveDirection * Time.deltaTime);
        }
    }
}