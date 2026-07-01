using UnityEngine;
using System;

public class InputListener : MonoBehaviour 
{
    private EternalGroveInputActions _inputActions;
    
    [HideInInspector] public Vector2 playerMovement;
    public event Action OnEscapePressed; 

    private void Awake() 
    {
        _inputActions = new EternalGroveInputActions();
    }

    private void OnEnable() 
    {
        _inputActions.Enable();
        _inputActions.Player.Escape.performed += HandleEscape;
    }

    private void OnDisable() 
    {
        _inputActions.Disable();
        _inputActions.Player.Escape.performed -= HandleEscape;
    }

    private void Update() 
    {
        playerMovement = _inputActions.Player.Move.ReadValue<Vector2>();
    }

    private void HandleEscape(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        OnEscapePressed?.Invoke();
    }
}