using UnityEngine;

public class Player_Defense : MonoBehaviour
{
    [SerializeField] private Player_State state;
    public void Hit(float damage)
    {
        state.currentHp -= damage;
    }
}
