using UnityEngine;

[CreateAssetMenu(fileName = "Tower1Upg 1", menuName = "Scriptable Objects/TowerUpgrades")]
public class TowerUpgradesSO : ScriptableObject
{
    public int upgCost;
    public int damage;
    public float attackSpeed;
    public float range;
    public bool canSeeHiden;
    [Header("Projectile")]
    public float projSpeed;
    public int penetration;
}
