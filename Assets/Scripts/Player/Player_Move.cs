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
    public void SetMove(Vector2 movement)
    {
        if(!isDashing)
            rb.linearVelocityX = movement.x * state.moveSpeed;
    }

    public void Dash()
    {
        isDashing = true;
        StartCoroutine(Dashing());
    }
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

    private IEnumerator Dashing()
    {
        float dashTime = 0;
        int direction = rb.linearVelocityX > 0 ? 1 : -1;
        while (dashTime < 0.15f)
        {
            rb.linearVelocity = new Vector2(state.dashForce * direction,0);
            dashTime += Time.deltaTime;
            yield return null;
        }
    
        isDashing = false;
        rb.linearVelocity = Vector2.zero;
    }
}
