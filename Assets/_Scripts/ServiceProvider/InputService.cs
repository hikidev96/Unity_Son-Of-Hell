using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace SOD
{
    public class InputService : MonoBehaviour, InputActions.IMovementActions
    {
        private InputActions inputActions;
        private Vector3 movementValue;

        public Vector3 MovementValue => movementValue;

        private void Awake()
        {
            inputActions = new InputActions();
            SetCallbacks();
        }

        private void OnEnable()
        {
            EnableInputActions();
        }        

        private void EnableInputActions()
        {
            inputActions.Movement.Enable();
        }

        private void SetCallbacks()
        {
            inputActions.Movement.SetCallbacks(this);
        }

        public void OnHorizontal(InputAction.CallbackContext context)
        {
            movementValue.x = context.ReadValue<float>();
        }

        public void OnVertical(InputAction.CallbackContext context)
        {
            movementValue.z = context.ReadValue<float>();
        }
    }
}
