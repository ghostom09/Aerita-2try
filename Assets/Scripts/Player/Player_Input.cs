using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player_Input : MonoBehaviour
{
    public event Action<Vector2> onMove;
    public event Action JumpStart;
    public event Action JumpEnd;
    public event Action onDash;
    public event Action attack;
    public void OnMove(InputAction.CallbackContext context)
    {
        onMove?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started) JumpStart?.Invoke();
        else if(context.canceled) JumpEnd?.Invoke();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if(context.started) onDash?.Invoke();
    }
    public void NormalAttack(InputAction.CallbackContext context)
    {
        if(context.started) attack?.Invoke();
    }

}
