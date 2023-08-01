using Cinemachine;
using UnityEngine;

namespace NeatWolf.FPS
{
    public class PlayerLook : MonoBehaviour
    {
        [SerializeField]
        CinemachineVirtualCamera virtualCamera;

        [SerializeField]
        float sensitivity = 2f;

        PlayerInputHandler inputHandler;

        float rotationX = 0f;

        void Awake()
        {
            inputHandler = GetComponent<PlayerInputHandler>();
        }

        void Update()
        {
            Look();
        }

        void Look()
        {
            Vector2 lookDirection = inputHandler.GetLook() * sensitivity;
            rotationX -= lookDirection.y;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);

            virtualCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
            transform.Rotate(Vector3.up * lookDirection.x);
        }
    }
}