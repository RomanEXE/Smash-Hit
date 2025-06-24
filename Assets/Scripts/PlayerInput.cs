using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class PlayerInput : MonoBehaviour
{
    public event Action<Vector2> FingerDown;

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
        FingerDown?.Invoke(obj.screenPosition);
    }
}