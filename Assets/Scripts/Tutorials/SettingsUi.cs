using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUi : MonoBehaviour
{
    [SerializeField] private List<SoundSlider> soundSliders = new List<SoundSlider>(3);
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private List<GameObject> towers;
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private GameObject UI;

    public void SetMusicVolume()
    {
        musicAudioSource.volume = soundSliders[2].slider.value * soundSliders[2].maxVolume;
        soundSliders[2].valueText.text = (soundSliders[2].slider.value).ToString("F2");
    }
    public void SetEnemiesVolume()
    {
        //soundSliders[0].slider.value
        for (int i = 0; i < enemies.Count; i++)
        {
            AudioSource audioSource = enemies[i].GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.volume = soundSliders[0].slider.value * soundSliders[0].maxVolume;
            }
        }
        for (int i = 0; i < CreateEnemy.Instance.GetEnemiesRemainsAlive().Count; i++)
        {
            AudioSource audioSourceAlive = CreateEnemy.Instance.GetEnemiesRemainsAlive()[i].GetComponent<AudioSource>();
            if (audioSourceAlive != null)
            {
                audioSourceAlive.volume = soundSliders[0].slider.value * soundSliders[0].maxVolume;
            }
        }
        soundSliders[0].valueText.text = (soundSliders[0].slider.value).ToString("F2");
    }
    public void SetTowersVolume()
    {
        //soundSliders[0].slider.value
        for (int i = 0; i < towers.Count; i++)
        {
            AudioSource audioSource = towers[i].GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.volume = soundSliders[1].slider.value * soundSliders[1].maxVolume;
            }
        }
        for (int i = 0; i < PlaceTower.Instance.GetPlacedTowerList().Count; i++)
        {
            AudioSource audioSourceAlive = PlaceTower.Instance.GetPlacedTowerList()[i].GetComponent<AudioSource>();
            if (audioSourceAlive != null)
            {
                audioSourceAlive.volume = soundSliders[1].slider.value * soundSliders[1].maxVolume;
            }
        }
        soundSliders[1].valueText.text = (soundSliders[1].slider.value).ToString("F2");
    }
    public void ToggleUI(bool bl)
    {
        UI.SetActive(bl);
    }

}
[System.Serializable]
public class SoundSlider
{
    public Slider slider;
    public float maxVolume;
    public Text valueText;
}
