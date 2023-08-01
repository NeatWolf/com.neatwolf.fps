using UnityEngine;

namespace NeatWolf.FPS
{
    public class PlayerLook : MonoBehaviour
    {
        [SerializeField]
        private PlayerInputHandler inputHandler;

        [SerializeField]
        private float sensitivity = 2f;

        [SerializeField]
        private float lowerAngleLimit = -60f;

        [SerializeField]
        private float upperAngleLimit = 60f;

        [SerializeField]
        private AnimationCurve horizontalSpeedCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

        [SerializeField]
        private AnimationCurve verticalSpeedCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

        private float verticalLookRotation;

        [SerializeField] 
        private Transform HorizontalRotationRoot;

        // Smoothing time for camera movements.
        // This value is a rough estimate of the time the smoothing takes to occur (in seconds).
        // It's calculated based on the frame rate and the desired number of frames over which to smooth.
        // For example, if targeting 60 FPS (where each frame is ~0.01667 seconds) and we want smoothing
        // to occur over approximately 2 frames, smoothTime could be set to 0.01667 * 2 = 0.03334 seconds.
        // The actual feel and results may vary depending on the game's logic and performance,
        // so testing and adjusting is necessary.
        private float smoothTime = 0.03334f; 

        void Update()
        {
            Look();
            LockCursor();
        }

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
