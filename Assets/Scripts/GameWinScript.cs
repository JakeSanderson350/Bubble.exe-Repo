using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("openStartScene", 5.0f);
    }

    private void openStartScene()
    {
        SceneManager.LoadScene("LoginScene");
    }
}
