using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace SOD
{
    public class InputService : MonoBehaviour, InputActions.IMovementActions, InputActions.IAttackActions
    {
        private InputActions inputActions;
        private UnityEvent onNormalAttackKeyPress = new UnityEvent();
        private UnityEvent onDashKeyPress = new UnityEvent();
        private Vector3 movementValue;
        private bool isNormalAttackKeyPress;

        public UnityEvent OnNormalAttackKeyPress => onNormalAttackKeyPress;
        public UnityEvent OnDashKeyPress => onDashKeyPress;
        public Vector3 MovementValue => movementValue;
        public Vector3 MousePositionInWorld => Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        public bool IsNormalAttackKeyPress => isNormalAttackKeyPress;

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
        }

        private void SetCallbacks()
        {
            inputActions.Movement.SetCallbacks(this);
            inputActions.Attack.SetCallbacks(this);
        }

        void InputActions.IMovementActions.OnHorizontal(InputAction.CallbackContext context)
        {
            movementValue.x = context.ReadValue<float>();
        }

        void InputActions.IMovementActions.OnVertical(InputAction.CallbackContext context)
        {
            movementValue.z = context.ReadValue<float>();
        }

        void InputActions.IAttackActions.OnNormalAttack(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onNormalAttackKeyPress.Invoke();
                isNormalAttackKeyPress = true;
            }
            else if (context.canceled)
            {
                isNormalAttackKeyPress = false;
            }
        }

        void InputActions.IMovementActions.OnDash(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onDashKeyPress.Invoke();
            }
        }
    }
}