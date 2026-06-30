using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private GameObject lvlUI;
    public void ChangeToScene(int sceneNum)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNum);
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
