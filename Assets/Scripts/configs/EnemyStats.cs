using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Scriptable Objects/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public int health;
    public float speed;
    public int damage;
    public int value;
    public bool isHidden;
}
