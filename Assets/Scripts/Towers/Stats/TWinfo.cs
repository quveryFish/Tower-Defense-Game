using System.Collections.Generic;
using UnityEngine;

public class TWinfo : MonoBehaviour
{
    public TowerType twType;
    public List<TowerUpgradesSO> towerUpgradesList;
    public int level = 0;
    public Sprite towerImage;
    public int price;

    private void Start()
    {
        SetStarterStat();
        level = 1;
    }
    public void Upgrade()
    {
        if (twType == TowerType.Shoot)
        {
            SetDamageUpgrades();
            SetRangeUpgrades();
            SetAttackSpeed();
            SetCanSeeHiden();
            //
            SetProjSpeed();
            SetPenetration();
        }
        else if (twType == TowerType.SplashMelee)
        {
            SetDamageUpgrades();
            SetRangeUpgrades();
            SetAttackSpeed();
            SetCanSeeHiden();
        }
        else if (twType == TowerType.Spawner)
        {
            SetSpawnSpeed();
            SetSpawnHealth();
            SetSpawnWalkSpeed();
        }
            price += towerUpgradesList[level - 1].upgCost;
    }

    private void SetStarterStat()
    {
        //Damage
        if (gameObject.GetComponent<TowerShoot>() != null)
        {
            gameObject.GetComponent<TowerShoot>().SetDamage(towerUpgradesList[0].damage);
        }
        else if (gameObject.GetComponent<TowerSplashMelee>() != null)
        {
            gameObject.GetComponent<TowerSplashMelee>().SetDamage(towerUpgradesList[0].damage);
        }
        //Range
        if (gameObject.GetComponent<TowerRotateToEnemy>() != null)
        {
            gameObject.GetComponent<TowerRotateToEnemy>().SetRange(towerUpgradesList[0].range);
        }
        //Attack Speed
        if (gameObject.GetComponent<TowerShoot>() != null)
        {
            gameObject.GetComponent<TowerShoot>().SetAttackCooldown(towerUpgradesList[0].attackSpeed);
        }
        else if (gameObject.GetComponent<TowerSplashMelee>() != null)
        {
            gameObject.GetComponent<TowerSplashMelee>().SetAttackCooldown(towerUpgradesList[0].attackSpeed);
        }
        //Projectile Speed
        if (gameObject.GetComponent<TowerShoot>() != null)
        {
            gameObject.GetComponent<TowerShoot>().SetProjSpeed(towerUpgradesList[0].projSpeed);
        }
        //Penetration
        if (gameObject.GetComponent<TowerShoot>() != null)
        {
            gameObject.GetComponent<TowerShoot>().SetPenetration(towerUpgradesList[0].penetration);
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
    private void SetCanSeeHiden()
    {
        if (gameObject.GetComponent<TowerRotateToEnemy>() != null)
        {
            gameObject.GetComponent<TowerRotateToEnemy>().SetCanSeeHiden(towerUpgradesList[level - 1].canSeeHiden);
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

    private void SetSpawnSpeed()
    {
        if (gameObject.GetComponent<TowerCreateMinions>() != null)
        {
            gameObject.GetComponent<TowerCreateMinions>().SetSpawnSpeed(towerUpgradesList[level - 1].spawnSpeed);
        }   
    }
    private void SetSpawnHealth()
    {
        if (gameObject.GetComponent<TowerCreateMinions>() != null)
        {
            gameObject.GetComponent<TowerCreateMinions>().SetSpawnHealth(towerUpgradesList[level - 1].spawnHealth);
        }
    }
    public void SetSpawnWalkSpeed()
    {
        if (gameObject.GetComponent<TowerCreateMinions>() != null)
        {
            gameObject.GetComponent<TowerCreateMinions>().SetMoveSpeed(towerUpgradesList[level - 1].spawnedWalkSpeed);
        }
    }
}
public enum TowerType
{
    Shoot,
    SplashMelee,
    Spawner
}
