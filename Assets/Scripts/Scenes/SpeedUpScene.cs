using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpScene : MonoBehaviour
{
    public void SpeedUpGame()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 5f;
            gameObject.GetComponent<Image>().color = Color.lightGray;
        }
        else
        {
            Time.timeScale = 1f;
            gameObject.GetComponent<Image>().color = Color.white;
        }
    }
}
