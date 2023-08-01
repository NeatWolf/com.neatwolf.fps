
using UnityEngine;

namespace NeatWolf.FPS
{
    public class PlayerInputHandler : MonoBehaviour
    {
        PlayerControls controls;
        Vector2 move;
        Vector2 look;
        bool isCrouching;

        void Awake()
        {
            controls = new PlayerControls();

            controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
            controls.Player.Move.canceled += ctx => move = Vector2.zero;

            controls.Player.Look.performed += ctx => look = ctx.ReadValue<Vector2>();
            controls.Player.Look.canceled += ctx => look = Vector2.zero;

            //controls.Player.Crouch.performed += ctx => isCrouching = !isCrouching;
        }

        void OnEnable()
        {
            controls.Player.Enable();
        }

        void OnDisable()
        {
            controls.Player.Disable();
        }

        public Vector2 GetMove()
        {
            return move;
        }

        public Vector2 GetLook()
        {
            return look;
        }

        public bool GetCrouching()
        {
            return isCrouching;
        }
    }
}