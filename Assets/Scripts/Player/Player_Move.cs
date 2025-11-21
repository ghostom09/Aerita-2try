using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Player_State state;
    private bool isGrounded;
    private bool isHeld;

    private bool isDashing;
    private bool canDash = true;
    public void SetMove(Vector2 movement)
    {
        if(!isDashing)
            rb.linearVelocityX = movement.x * state.moveSpeed;
    }

    // public void Dash()
    // {
    //     if (canDash)
    //     {
    //          isDashing = true;
    //          canDash = false;
    //          // StartCoroutine(Dashing());
    //     }
    //    
    // }
    public void JumpStart()
    {
        if (isGrounded)
        {
            isHeld = true;
            rb.linearVelocityY = state.jumpHeight;    
        }
    }
    public void JumpEnd()
    {
        isHeld = false;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 0.5f),
            new Vector2(0.7f, 0.2f), 0, LayerMask.GetMask("Ground"));
        if(rb.linearVelocityY < 0) rb.linearVelocityY += Physics.gravity.y * 1.5f * Time.deltaTime;
        else if(!isGrounded && !isHeld) rb.linearVelocityY += Physics.gravity.y * 3 * Time.deltaTime;
    }

    // private IEnumerator Dashing()
    // {
    //     float dashTime = 0;
    //     int direction = rb.linearVelocityX > 0 ? 1 : -1;
    //
    //     float myPosX = rb.position.x;
    //     float targetPosX = direction * state.dashForce;
    //     
    //     Vector2 startPos = new Vector2(myPosX, rb.position.y);
    //     Vector2 endPos = new Vector2(targetPosX + myPosX, rb.position.y);
    //
    //     rb.linearVelocityY = 0;
    //     while (dashTime < 0.15f)
    //     {
    //         rb.MovePosition(Vector2.Lerp(startPos,endPos, dashTime / 0.15f));
    //         dashTime += Time.deltaTime;
    //         yield return null;
    //     }
    //
    //     rb.MovePosition(endPos);
    //     isDashing = false; 
    //     
    //     yield return new WaitForSeconds(state.dashCoolTime);
    //
    //     canDash = true;
    // }
}
