using UnityEngine;

[CreateAssetMenu(fileName = "Tower1Upg 1", menuName = "Scriptable Objects/TowerUpgrades")]
public class TowerUpgrades : ScriptableObject
{
    public int upgCost;
    public int damage;
    public float attackSpeed;
    public float range;
    public float projSpeed;
    public int penetration;
}
