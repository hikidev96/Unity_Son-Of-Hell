using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace SOD
{
    public class InputService : MonoBehaviour, InputActions.IMovementActions, InputActions.IAttackActions, InputActions.IInteractionActions
    {
        private InputActions inputActions;
        private UnityEvent onHandFireKeyPress = new UnityEvent();
        private UnityEvent onDashKeyPress = new UnityEvent();
        private UnityEvent onInteractKeyPress = new UnityEvent();
        private Vector3 movementValue;
        private bool isHandFireKeyPress;

        public UnityEvent OnHandFireKeyPress => onHandFireKeyPress;
        public UnityEvent OnDashKeyPress => onDashKeyPress;
        public UnityEvent OnInteractKeyPress => onInteractKeyPress;
        public Vector3 MovementValue => movementValue;
        public Vector3 MousePositionInWorld => Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        public bool IsHandFireKeyPress => isHandFireKeyPress;

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
            inputActions.Attack.Enable();
            inputActions.Interaction.Enable();
        }

        private void SetCallbacks()
        {
            inputActions.Movement.SetCallbacks(this);
            inputActions.Attack.SetCallbacks(this);
            inputActions.Interaction.SetCallbacks(this);
        }

        void InputActions.IMovementActions.OnHorizontal(InputAction.CallbackContext context)
        {
            movementValue.x = context.ReadValue<float>();
        }

        void InputActions.IMovementActions.OnVertical(InputAction.CallbackContext context)
        {
            movementValue.z = context.ReadValue<float>();
        }

        void InputActions.IAttackActions.OnHandFire(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onHandFireKeyPress.Invoke();
                isHandFireKeyPress = true;
            }
            else if (context.canceled)
            {
                isHandFireKeyPress = false;
            }
        }

        void InputActions.IMovementActions.OnDash(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onDashKeyPress.Invoke();
            }
        }

        void InputActions.IInteractionActions.OnInteract(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onInteractKeyPress.Invoke();
            }
        }
    }
}