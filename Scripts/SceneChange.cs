using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void PlayScene()
    {
        SceneManager.LoadScene("Game");
    }
}
