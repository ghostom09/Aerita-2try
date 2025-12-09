using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player_Attack : MonoBehaviour
{
    [SerializeField] private Player_State player;
    public WeaponData currentWeapon;
    public AttackHitBox hitbox;

    void Start()
    {
        EquipWeapon(currentWeapon);
    }
    public void EquipWeapon(WeaponData newWeapon)
    {
        currentWeapon = newWeapon;
        hitbox.ApplyWeapon(currentWeapon);
    }

    public void Attack()
    {
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        hitbox.transform.localPosition = new Vector2(currentWeapon.range / 2 * player.direction, 0);
        hitbox.gameObject.SetActive(true);

        yield return new WaitForSeconds(currentWeapon.duration);

        hitbox.gameObject.SetActive(false);
    }
}
