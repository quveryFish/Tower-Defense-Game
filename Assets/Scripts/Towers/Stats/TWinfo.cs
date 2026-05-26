using System.Collections.Generic;
using UnityEngine;

public class TWinfo : MonoBehaviour
{
    [SerializeField] private TowerUpgrades startingStats;
    public List<TowerUpgrades> towerUpgradesList;
    public int level;
    public Sprite towerImage;
    public int price;

    private void Start()
    {
        SetStarterStat();
    }
    public void Upgrade()
    {
        SetDamageUpgrades();
        SetRangeUpgrades();
        SetAttackSpeed();
        //RangeOnlyUpgrades();
        SetProjSpeed();
        SetPenetration();
        price += towerUpgradesList[level - 1].upgCost;
    }

    private void SetStarterStat()
    {
        //Damage
        if (gameObject.GetComponent<TowerShoot>() != null)
        {
            gameObject.GetComponent<TowerShoot>().SetDamage(startingStats.damage);
        }
        else if (gameObject.GetComponent<TowerSplashMelee>() != null)
        {
            gameObject.GetComponent<TowerSplashMelee>().SetDamage(startingStats.damage);
        }
        //Range
        if (gameObject.GetComponent<TowerRotateToEnemy>() != null)
        {
            gameObject.GetComponent<TowerRotateToEnemy>().SetRange(startingStats.range);
        }
        //Attack Speed
        if (gameObject.GetComponent<TowerShoot>() != null)
        {
            gameObject.GetComponent<TowerShoot>().SetAttackCooldown(startingStats.attackSpeed);
        }
        else if (gameObject.GetComponent<TowerSplashMelee>() != null)
        {
            gameObject.GetComponent<TowerSplashMelee>().SetAttackCooldown(startingStats.attackSpeed);
        }
        //Projectile Speed
        if (gameObject.GetComponent<TowerShoot>() != null)
        {
            gameObject.GetComponent<TowerShoot>().SetProjSpeed(startingStats.projSpeed);
        }
        //Penetration
        if (gameObject.GetComponent<TowerShoot>() != null)
        {
            gameObject.GetComponent<TowerShoot>().SetPenetration(startingStats.penetration);
        }
    }
    private void SetDamageUpgrades()
    {
        if (gameObject.GetComponent<TowerShoot>() != null)
        {
            gameObject.GetComponent<TowerShoot>().SetDamage(towerUpgradesList[level - 1].damage);
        }
        else if (gameObject.GetComponent<TowerSplashMelee>() != null)
        {
            gameObject.GetComponent<TowerSplashMelee>().SetDamage(towerUpgradesList[level - 1].damage);
        }
    }
    private void SetRangeUpgrades()
    {
        if (gameObject.GetComponent<TowerRotateToEnemy>() != null)
        {
            gameObject.GetComponent<TowerRotateToEnemy>().SetRange(towerUpgradesList[level - 1].range
            );
        }
    }
    private void SetAttackSpeed()
    {
        if (gameObject.GetComponent<TowerShoot>() != null)
        {
            gameObject.GetComponent<TowerShoot>().SetAttackCooldown(towerUpgradesList[level - 1].attackSpeed);
        }
        else if (gameObject.GetComponent<TowerSplashMelee>() != null)
        {
            gameObject.GetComponent<TowerSplashMelee>().SetAttackCooldown(towerUpgradesList[level - 1].attackSpeed);
        }
    }
    private void SetProjSpeed()
    {
        if (gameObject.GetComponent<TowerShoot>() != null)
        {
            gameObject.GetComponent<TowerShoot>().SetProjSpeed(towerUpgradesList[level - 1].projSpeed);
        }
    }
    private void SetPenetration()
    {
        if (gameObject.GetComponent<TowerShoot>() != null)
        {
            gameObject.GetComponent<TowerShoot>().SetPenetration(towerUpgradesList[level - 1].penetration);
        }
    }
}
