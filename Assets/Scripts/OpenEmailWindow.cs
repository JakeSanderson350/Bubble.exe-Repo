using UnityEngine;

public class OpenEmailWindow : MonoBehaviour
{
    [SerializeField] GameObject emailWindow;

    public void OpenEmail()
    {
        emailWindow.SetActive(true);
    }
}
