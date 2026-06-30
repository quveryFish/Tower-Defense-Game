using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwStats : MonoBehaviour
{
    [SerializeField] private List<Text> currentStatText; // damage, range, attack speed, projectile speed, penetration
    [SerializeField] private Image hiddenStatus;
    [SerializeField] private List<GameObject> upgStatText;
    [SerializeField] private List<GameObject> arrows;
    private TowerUpgradesSO upgrade;
    private TWinfo currentTWinfo;
    public void SetStats(TWinfo currentTWinfo_)
    {
        currentTWinfo = currentTWinfo_;
        if (currentTWinfo.level >= 1)
        {
            upgrade = currentTWinfo.towerUpgradesList[currentTWinfo.level - 1];
        }
        if (currentTWinfo.level == 0)
        {
            if (currentTWinfo.twType == TowerType.Shoot)
            {
                currentStatText[0].text = $"Damage - {currentTWinfo.towerUpgradesList[0].damage}";
                currentStatText[1].text = $"Range - {currentTWinfo.towerUpgradesList[0].range}";
                currentStatText[2].text = $"Attack Speed - {currentTWinfo.towerUpgradesList[0].attackSpeed}";
                currentStatText[3].text = $"Projectile Speed - {currentTWinfo.towerUpgradesList[0].projSpeed}";
                currentStatText[4].text = $"Penetration - {currentTWinfo.towerUpgradesList[0].penetration}";
            }
            else if (currentTWinfo.twType == TowerType.SplashMelee)
            {
                currentStatText[0].text = $"Damage - {currentTWinfo.towerUpgradesList[0].damage}";
                currentStatText[1].text = $"Range - {currentTWinfo.towerUpgradesList[0].range}";
                currentStatText[2].text = $"Attack Speed - {currentTWinfo.towerUpgradesList[0].attackSpeed}";
                currentStatText[3].text = "  ";
                currentStatText[4].text = "  ";
            }
            else if (currentTWinfo.twType == TowerType.Spawner)
            {
                currentStatText[0].text = $"Health - {currentTWinfo.towerUpgradesList[0].spawnHealth}";
                currentStatText[1].text = $"Deploy Time - {currentTWinfo.towerUpgradesList[0].spawnSpeed}";
                currentStatText[2].text = $"Walk Speed - {currentTWinfo.towerUpgradesList[0].spawnedWalkSpeed}";
                currentStatText[3].text = "  ";
                currentStatText[4].text = "  ";
            }
            CheckCanSeeHidden();
        }
        else
        {
            if (currentTWinfo.level - 1 < currentTWinfo.towerUpgradesList.Count - 1)
            {
                CheckStat();
            }
            CheckCanSeeHidden();
            SetNewCurrentText();
        }

    }
    private void SetNewCurrentText()
    {
        if (currentTWinfo.twType == TowerType.Shoot)
        {
            currentStatText[0].text = $"Damage - {upgrade.damage}";
            currentStatText[1].text = $"Range - {upgrade.range}";
            currentStatText[2].text = $"Attack Speed - {upgrade.attackSpeed}";
            currentStatText[3].text = $"Projectile Speed - {upgrade.projSpeed}";
            currentStatText[4].text = $"Penetration - {upgrade.penetration}";
        }
        else if (currentTWinfo.twType == TowerType.SplashMelee)
        {
            currentStatText[0].text = $"Damage - {upgrade.damage}";
            currentStatText[1].text = $"Range - {upgrade.range}";
            currentStatText[2].text = $"Attack Speed - {upgrade.attackSpeed}";
            currentStatText[3].text = $"  ";
            currentStatText[4].text = $"  ";
        }
        else if (currentTWinfo.twType == TowerType.Spawner)
        {
            currentStatText[0].text = $"Health - {upgrade.spawnHealth}";
            currentStatText[1].text = $"Deploy Time - {upgrade.spawnSpeed}";
            currentStatText[2].text = $"Walk Speed - {upgrade.spawnedWalkSpeed}";
            currentStatText[3].text = $"  ";
            currentStatText[4].text = $"  ";
        }

    }
    private void CheckStat()
    {
        if (upgrade.damage != currentTWinfo.towerUpgradesList[currentTWinfo.level].damage
            && (currentTWinfo.twType == TowerType.Shoot || currentTWinfo.twType == TowerType.SplashMelee))
        {
            arrows[0].SetActive(true);
            upgStatText[0].SetActive(true);
            upgStatText[0].GetComponent<Text>().text = $"{currentTWinfo.towerUpgradesList[currentTWinfo.level].damage}";
        }
        if (upgrade.range != currentTWinfo.towerUpgradesList[currentTWinfo.level].range
            && (currentTWinfo.twType == TowerType.Shoot || currentTWinfo.twType == TowerType.SplashMelee))
        {
            arrows[1].SetActive(true);
            upgStatText[1].SetActive(true);
            upgStatText[1].GetComponent<Text>().text = $"{currentTWinfo.towerUpgradesList[currentTWinfo.level].range}";
        }
        if (upgrade.attackSpeed != currentTWinfo.towerUpgradesList[currentTWinfo.level].attackSpeed
            && (currentTWinfo.twType == TowerType.Shoot || currentTWinfo.twType == TowerType.SplashMelee))
        {
            arrows[2].SetActive(true);
            upgStatText[2].SetActive(true);
            upgStatText[2].GetComponent<Text>().text = $"{currentTWinfo.towerUpgradesList[currentTWinfo.level].attackSpeed}";
        }
        if (upgrade.projSpeed != currentTWinfo.towerUpgradesList[currentTWinfo.level].projSpeed
            && currentTWinfo.twType == TowerType.Shoot)
        {
            arrows[3].SetActive(true);
            upgStatText[3].SetActive(true);
            upgStatText[3].GetComponent<Text>().text = $"{currentTWinfo.towerUpgradesList[currentTWinfo.level].projSpeed}";
        }
        if (upgrade.penetration != currentTWinfo.towerUpgradesList[currentTWinfo.level].penetration
             && currentTWinfo.twType == TowerType.Shoot)
        {
            arrows[4].SetActive(true);
            upgStatText[4].SetActive(true);
            upgStatText[4].GetComponent<Text>().text = $"{currentTWinfo.towerUpgradesList[currentTWinfo.level].penetration}";
        }
        ///////////////////////
        if (upgrade.spawnHealth != currentTWinfo.towerUpgradesList[currentTWinfo.level].spawnHealth
            && currentTWinfo.twType == TowerType.Spawner)
        {
            arrows[0].SetActive(true);
            upgStatText[0].SetActive(true);
            upgStatText[0].GetComponent<Text>().text = $"{currentTWinfo.towerUpgradesList[currentTWinfo.level].spawnHealth}";
        }
        if (upgrade.spawnSpeed != currentTWinfo.towerUpgradesList[currentTWinfo.level].spawnSpeed
            && currentTWinfo.twType == TowerType.Spawner)
        {
            arrows[1].SetActive(true);
            upgStatText[1].SetActive(true);
            upgStatText[1].GetComponent<Text>().text = $"{currentTWinfo.towerUpgradesList[currentTWinfo.level].spawnSpeed}";
        }
        if (upgrade.spawnedWalkSpeed != currentTWinfo.towerUpgradesList[currentTWinfo.level].spawnedWalkSpeed
            && currentTWinfo.twType == TowerType.Spawner)
        {
            arrows[2].SetActive(true);
            upgStatText[2].SetActive(true);
            upgStatText[2].GetComponent<Text>().text = $"{currentTWinfo.towerUpgradesList[currentTWinfo.level].spawnedWalkSpeed}";
        }

        CheckCanSeeHidden();
    }
    private void CheckCanSeeHidden()
    {
        if (upgrade.canSeeHiden)
        {
            hiddenStatus.color = Color.green;
        }
        else
        {
            hiddenStatus.color = Color.red;
        }
    }
    public void ClearUpg()
    {
        for (int i = 0; i < arrows.Count; i++)
        {
            arrows[i].SetActive(false);
            upgStatText[i].SetActive(false);
        }
    }

}
