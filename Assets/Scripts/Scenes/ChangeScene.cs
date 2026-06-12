using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void ChangeToScene(int sceneNum)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNum);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
