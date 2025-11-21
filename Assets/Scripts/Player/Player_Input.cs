using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Input : MonoBehaviour
{
    public event Action<Vector2> onMove;
    public event Action jumpStart;
    public event Action jumpEnd;
    public event Action onDash;
    public void OnMove(InputAction.CallbackContext context)
    {
        onMove?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started) jumpStart?.Invoke();
        else if(context.canceled) jumpEnd?.Invoke();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        onDash?.Invoke();
    }
}
