using UnityEngine;
using UnityEngine.InputSystem;

public class RotatorUsingInput : MonoBehaviour
{
    [SerializeField] private InputActionReference horizontalKey;
    [SerializeField] private InputActionReference verticalKey;

    private Rotator rotator;
    private Vector3 goalDir;

    private void Awake()
    {
        rotator = new Rotator(this.transform);
    }

    private void OnEnable()
    {
        horizontalKey.action.Enable();
        verticalKey.action.Enable();
    }

    private void Start()
    {
        horizontalKey.action.started += ReadHorizontalValueFromInput;
        verticalKey.action.started += ReadVerticalValueFromInput;
        horizontalKey.action.canceled += ReadHorizontalValueFromInput;
        verticalKey.action.canceled += ReadVerticalValueFromInput;
    }

    private void Update()
    {
        if (goalDir == Vector3.zero)
        {
            return;
        }
        
        rotator.RotateSmoothly(goalDir, true);
    }

    private void ReadHorizontalValueFromInput(InputAction.CallbackContext context)
    {
        goalDir = new Vector3(context.ReadValue<float>(), goalDir.y, goalDir.z);
    }

    private void ReadVerticalValueFromInput(InputAction.CallbackContext context)
    {
        goalDir = new Vector3(goalDir.x, goalDir.y, context.ReadValue<float>());
    }
}