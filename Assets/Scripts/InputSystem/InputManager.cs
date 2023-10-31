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
        gameControls.Enable();
        gameControls.Player.Hit.performed += Hit;
    }

    private void Hit(InputAction.CallbackContext context)
    {
        TouchSimulation.Enable();
        Vector2 touchPosition = Touchscreen.current.position.ReadValue();
        Debug.Log($"Touch screen position: {touchPosition}");
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
        Debug.Log($"Touch world position: {worldPosition}");
        OnHit?.Invoke(touchPosition);
        //Também pode ser escrito como:
        //if (OnHit == null)
        //{
        //    return;
        //}
        //else
        //{
        //    OnHit.Invoke();
        //}
    }
}
