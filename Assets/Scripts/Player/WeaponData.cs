using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public float damage;
    public float range;
    public float width;
    public float duration;

}
