using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void ChangeToScene(int sceneNum)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNum);
    }
}
