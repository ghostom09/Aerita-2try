using UnityEngine;

public class Player_State : MonoBehaviour
{
    [Header("basic stat")] 
    public float hp;
    public float currentHp;
    public float breath;
    public float stamina;
    public float damage;


    [Header("movement stat")] 
    public float moveSpeed;
    public float jumpHeight;
    public float dashCoolTime;
    public float dashForce;


}
