using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    public void PlayScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
