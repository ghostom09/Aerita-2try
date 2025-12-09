using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    private BoxCollider2D col;

    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        gameObject.SetActive(false);
    }

    public void ApplyWeapon(WeaponData weapon)
    {   
        col.size = new Vector2(weapon.range, weapon.width);
    }
    
}
