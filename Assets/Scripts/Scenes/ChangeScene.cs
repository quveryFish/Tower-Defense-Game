using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private GameObject lvlUI;
    public void ChangeToScene(int sceneNum)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNum);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void lvlUIsetBool(bool bl)
    {
        lvlUI.SetActive(bl);
    }
}
