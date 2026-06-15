using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwStats : MonoBehaviour
{
    [SerializeField] private List<Text> currentStatText; // damage, range, attack speed, projectile speed, penetration
    [SerializeField] private Image hiddenStatus;
    [SerializeField] private List<GameObject> upgStatText;
    [SerializeField] private List<GameObject> arrows;
    private TowerUpgrades upgrade;
    private TWinfo currentTWinfo;

    private void FixedUpdate()
    {
        if (currentTWinfo == null)
        {
            currentTWinfo = GetComponentInParent<TWinfoPanel>().GetCurrentTW();
        }
        else
        {
            if (currentTWinfo.level >= 1)
            {
                upgrade = currentTWinfo.towerUpgradesList[currentTWinfo.level - 1];
            }
            if (currentTWinfo.level == 0)
            {
                currentStatText[0].text = $"Damage - {currentTWinfo.towerUpgradesList[0].damage}";
                currentStatText[1].text = $"Range - {currentTWinfo.towerUpgradesList[0].range}";
                currentStatText[2].text = $"Attack Speed - {currentTWinfo.towerUpgradesList[0].attackSpeed}";
                currentStatText[3].text = $"Projectile Speed - {currentTWinfo.towerUpgradesList[0].projSpeed}";
                currentStatText[4].text = $"Penetration - {currentTWinfo.towerUpgradesList[0].penetration}";
                CheckCanSeeHidden();
            }
            else
            {
                if (currentTWinfo.level < currentTWinfo.towerUpgradesList.Count)
                {
                    CheckStat();
                    SetUpgradesText();
                }
                CheckCanSeeHidden();
            }

        }


    }

    private void SetUpgradesText()
    {
        currentStatText[0].text = $"Damage - {upgrade.damage}";
        currentStatText[1].text = $"Range - {upgrade.range}";
        currentStatText[2].text = $"Attack Speed - {upgrade.attackSpeed}";
        currentStatText[3].text = $"Projectile Speed - {upgrade.projSpeed}";
        currentStatText[4].text = $"Penetration - {upgrade.penetration}";
    }
    private void CheckStat()
    {
        if (upgrade.damage != currentTWinfo.towerUpgradesList[currentTWinfo.level].damage)
        {
            arrows[0].SetActive(true);
            upgStatText[0].SetActive(true);
            upgStatText[0].GetComponent<Text>().text = $"{currentTWinfo.towerUpgradesList[currentTWinfo.level].damage}";
        }
        if (upgrade.range != currentTWinfo.towerUpgradesList[currentTWinfo.level].range)
        {
            arrows[1].SetActive(true);
            upgStatText[1].SetActive(true);
            upgStatText[1].GetComponent<Text>().text = $"{currentTWinfo.towerUpgradesList[currentTWinfo.level].range}";
        }
        if (upgrade.attackSpeed != currentTWinfo.towerUpgradesList[currentTWinfo.level].attackSpeed)
        {
            arrows[2].SetActive(true);
            upgStatText[2].SetActive(true);
            upgStatText[2].GetComponent<Text>().text = $"{currentTWinfo.towerUpgradesList[currentTWinfo.level].attackSpeed}";
        }
        if (upgrade.projSpeed != currentTWinfo.towerUpgradesList[currentTWinfo.level].projSpeed)
        {
            arrows[3].SetActive(true);
            upgStatText[3].SetActive(true);
            upgStatText[3].GetComponent<Text>().text = $"{currentTWinfo.towerUpgradesList[currentTWinfo.level].projSpeed}";
        }
        if (upgrade.penetration != currentTWinfo.towerUpgradesList[currentTWinfo.level].penetration)
        {
            arrows[4].SetActive(true);
            upgStatText[4].SetActive(true);
            upgStatText[4].GetComponent<Text>().text = $"{currentTWinfo.towerUpgradesList[currentTWinfo.level].penetration}";
        }
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
        CheckCanSeeHidden();
    }

}
