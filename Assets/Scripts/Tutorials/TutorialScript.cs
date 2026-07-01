using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] private List<string> tutorialMessages;
    [SerializeField] private int currentMessageIndex = 0;
    [SerializeField] private Text messagePanel;
    private float timer;
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0 && messagePanel.text != "" && messagePanel.text != "Press space to start a wave")
        {
            DissableMessege();
        }
    }
    public void DissableMessege()
    {
        messagePanel.text = "";
    }
    public void ShowMessage()
    {
        if (currentMessageIndex < tutorialMessages.Count)
        {
            timer = 10;
            messagePanel.text = tutorialMessages[currentMessageIndex];
            currentMessageIndex++;
        }
    }
}