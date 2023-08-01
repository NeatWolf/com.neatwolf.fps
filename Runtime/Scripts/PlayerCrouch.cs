using UnityEngine;

namespace NeatWolf.FPS
{
    public class PlayerCrouch : MonoBehaviour
    {
        [SerializeField]
        private PlayerInputHandler inputHandler;

        [SerializeField]
        private Transform headTransform;

        [SerializeField]
        private AnimationCurve crouchCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

        [SerializeField]
        private Transform standingHeadRef;

        [SerializeField]
        private Transform crouchingHeadRef;

        private bool isCrouching;

        void Update()
        {
            if (inputHandler.GetCrouching())
            {
                isCrouching = !isCrouching;
            }

            Vector3 targetPosition = isCrouching ? crouchingHeadRef.localPosition : standingHeadRef.localPosition;
            Vector3 newPosition = Vector3.Lerp(headTransform.localPosition, targetPosition, crouchCurve.Evaluate(Time.deltaTime));
            headTransform.localPosition = newPosition;
        }
    }
}