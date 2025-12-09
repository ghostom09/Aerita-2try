using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Player_State state;
    private bool _isGrounded;
    private bool _isHeld;
    private Vector2 movement;

    private bool _isDashing;
    private bool _canDash = true;
    public void SetMove(Vector2 move)
    {
        movement = move;
    }

    public void Dash()
    {
        if (_canDash)
        {
             _isDashing = true;
             _canDash = false;
             StartCoroutine(Dashing());
        }
       
    }
    public void JumpStart()
    {
        if (_isGrounded)
        {
            _isHeld = true;
            rb.linearVelocityY = state.jumpHeight;    
        }
    }
    public void JumpEnd()
    {
        _isHeld = false;
    }

    void FixedUpdate()
    {
        if (!_isDashing)
        {
            rb.linearVelocityX = movement.x * state.moveSpeed;
            if (movement.x > 0) state.direction = 1;
            else if(movement.x < 0) state.direction = -1;
        }
        
        _isGrounded = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 0.5f),
            new Vector2(0.6f, 0.2f), 0, LayerMask.GetMask("Ground"));
        if(rb.linearVelocityY < 0) rb.linearVelocityY += Physics.gravity.y * 1.5f * Time.deltaTime;
        else if(!_isGrounded && !_isHeld) rb.linearVelocityY += Physics.gravity.y * 3 * Time.deltaTime;
    }
    private IEnumerator Dashing()
    {
        float dashTime = 0;
        float myPosX = rb.position.x;
        float targetPosX = state.direction * state.dashForce;
        
        Vector2 startPos = new Vector2(myPosX, rb.position.y);
        Vector2 endPos = new Vector2(targetPosX + myPosX, rb.position.y);
    
        rb.linearVelocityY = 0;
        while (dashTime < 0.15f)
        {
            rb.MovePosition(Vector2.Lerp(startPos,endPos, dashTime / 0.15f));
            dashTime += Time.deltaTime;
            yield return null;
        }
    
        rb.MovePosition(endPos);
        _isDashing = false; 
        
        yield return new WaitForSeconds(state.dashCoolTime);
    
        _canDash = true;
    }
}
