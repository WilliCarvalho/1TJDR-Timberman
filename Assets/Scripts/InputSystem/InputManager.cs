using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class InputManager
{
    public event Action<Vector2> OnHit;

    private GameControls gameControls;

    public InputManager()
    {
        gameControls = new(); // igual new GameControls()
        EnableInput();
        gameControls.Player.Hit.performed += Hit;
    }

    private void Hit(InputAction.CallbackContext context)
    {
        TouchSimulation.Enable();
        Vector2 touchPosition = Touchscreen.current.position.ReadValue();
        Debug.Log($"Touch screen position: {touchPosition}");
        
        Vector2 touchWorldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
        Debug.Log($"Touch world position: {touchWorldPosition}");
        
        OnHit?.Invoke(touchPosition);
        //Também pode ser escrito como:
        //if (OnHit != null)
        //{
        //    OnHit.Invoke();
        //}
        //else
        //{
        //    return;
        //}
    }

    public void DisableInput()
    {
        gameControls.Disable();
    }

    private void EnableInput()
    {
        gameControls.Enable();
    }
}
