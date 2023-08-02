using UnityEngine;

namespace NeatWolf.FPS
{
    /// <summary>
    /// Controls the player's camera look movement.
    /// </summary>
    public class PlayerLook : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The input handler for player look input. Handles mouse or joystick input.")]
        private PlayerInputHandler inputHandler;

        [SerializeField]
        [Tooltip("The sensitivity of the player's look movement. Higher values result in faster camera movement. Valid range: 0.1 to 10.")]
        [Range(0.1f, 10f)]
        private float sensitivity = 2f;

        [SerializeField]
        [Tooltip("The lower angle limit for vertical look rotation. Specifies the lowest angle the camera can look downwards. Valid range: -90 to 0.")]
        [Range(-90f, 0f)]
        private float lowerAngleLimit = -60f;

        [SerializeField]
        [Tooltip("The upper angle limit for vertical look rotation. Specifies the highest angle the camera can look upwards. Valid range: 0 to 90.")]
        [Range(0f, 90f)]
        private float upperAngleLimit = 60f;

        [SerializeField]
        [Tooltip("The animation curve for horizontal look speed. Allows customizing the speed curve for horizontal camera movement.")]
        private AnimationCurve horizontalSpeedCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

        [SerializeField]
        [Tooltip("The animation curve for vertical look speed. Allows customizing the speed curve for vertical camera movement.")]
        private AnimationCurve verticalSpeedCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

        private float verticalLookRotation;

        [SerializeField]
        [Tooltip("The root transform for horizontal rotation. Specifies the transform that rotates horizontally along with the player.")]
        private Transform HorizontalRotationRoot;

        [SerializeField]
        [Tooltip("The smoothing time for camera movements. Determines how quickly the camera movement is smoothed. Valid range: 0.01 to 1.")]
        [Range(0.01f, 1f)]
        private float smoothTime = 0.03334f;

        /// <summary>
        /// Updates the camera look movement.
        /// </summary>
        void Update()
        {
            Look();
            LockCursor();
        }

        /// <summary>
        /// Performs the camera look movement based on input.
        /// </summary>
        void Look()
        {
            Vector2 lookInput = inputHandler.GetLook();
            float horizontalSpeedScale = horizontalSpeedCurve.Evaluate(Mathf.Abs(lookInput.x));
            float verticalSpeedScale = verticalSpeedCurve.Evaluate(Mathf.Abs(lookInput.y));

            float adjustedHorizontalSpeed = sensitivity * horizontalSpeedScale * lookInput.x * Time.deltaTime;
            float adjustedVerticalSpeed = sensitivity * verticalSpeedScale * lookInput.y * Time.deltaTime;

            // Rotate Player horizontally.
            HorizontalRotationRoot.rotation *= Quaternion.Euler(0, adjustedHorizontalSpeed, 0);

            // Rotate camera vertically.
            verticalLookRotation += adjustedVerticalSpeed;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, lowerAngleLimit, upperAngleLimit);
            transform.localEulerAngles = Vector3.left * verticalLookRotation;
        }

        /// <summary>
        /// Locks or unlocks the cursor based on application focus.
        /// </summary>
        void LockCursor()
        {
            if (Application.isFocused)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
