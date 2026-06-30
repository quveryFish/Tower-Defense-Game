using System.Collections.Generic;
using UnityEngine;

public class SetEnemyStats : MonoBehaviour
{
    [SerializeField] private List<EnemyStats> enemyStatsList;
    [SerializeField] private int level = 0;
    void Awake()
    {
        SetEnemyDamage();
        SetEnemyHealth();
        SetEnemySpeed();
        SetEnemyValue();
        SetEnemyHidden();
    }

    private void SetEnemyDamage()
    {
        gameObject.GetComponent<EnemyDealDamageToBase>().SetDamageAmount(enemyStatsList[level].damage);
    }
    private void SetEnemyHealth()
    {
        gameObject.GetComponent<EnemyHealth>().SetEnemyHealth(enemyStatsList[level].health);
    }
    private void SetEnemySpeed()
    {
        gameObject.GetComponent<EnemyMovement>().SetSpeed(enemyStatsList[level].speed);
    }
    private void SetEnemyValue()
    {
        gameObject.GetComponent<EnemyHealth>().SetMoneyValue(enemyStatsList[level].value);
    }
    private void SetEnemyHidden()
    {
        gameObject.GetComponent<EnemyHealth>().SetIsHiden(enemyStatsList[level].isHidden);
    }

}
