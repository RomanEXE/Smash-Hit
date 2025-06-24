using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class PlayerInput : MonoBehaviour
{
    public Action FingerDown { get; set; } 

    private void OnEnable()
    {
        TouchSimulation.Enable();
        EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += OnFingerDown;
    }

    private void OnDisable()
    {
        EnhancedTouch.Touch.onFingerDown -= OnFingerDown;
        
        TouchSimulation.Disable();
        EnhancedTouchSupport.Disable();
    }

    private void OnFingerDown(Finger obj)
    {
        FingerDown?.Invoke();
        print("click");
    }

    public Vector2 GetTouchWorldPosition()
    {
        Vector2 screenPosition = EnhancedTouch.Touch.activeTouches[0].screenPosition;
        return Camera.main.ScreenToWorldPoint(screenPosition);
    }
}