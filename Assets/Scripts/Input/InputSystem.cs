using ScriptableObjectArchitecture;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private Vector2Reference movement;
    [SerializeField] private BoolReference shooting;
    private Controls touchControls;

    private void Awake()
    {
        touchControls = new Controls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
        touchControls.Mobile.Movement.performed += context => movement.Value = context.ReadValue<Vector2>();
        touchControls.Mobile.Shoot.performed += context => shooting.Value = true;
        touchControls.Mobile.Shoot.canceled += context => shooting.Value = false;
    }

    private void OnDisable()
    {
        touchControls.Disable();
        touchControls.Mobile.Movement.performed -= context => movement.Value = context.ReadValue<Vector2>();
        touchControls.Mobile.Shoot.performed -= context => shooting.Value = true;
        touchControls.Mobile.Shoot.canceled -= context => shooting.Value = false;
    }
}
