using System;
using UnityEngine;

namespace Components
{
    public class Input : MonoBehaviour
    {
        private Movement movement;
        private PlayerInputActions inputActions;
        private Vector2 movementInput;

        private void Awake()
        {
            inputActions = new PlayerInputActions();
            movement = GetComponent<Movement>();
            inputActions.PlayerControls.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            movement.Move(new Vector2(movementInput.x, movementInput.y));
        }

        private void OnEnable()
        {
            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }
    }
}
