using UnityEngine;

public class OpenEmailWindow : MonoBehaviour
{
    [SerializeField] GameObject emailWindow;
    [SerializeField] GameObject typingEmail;
    [SerializeField] GameObject readingEmail;

    public void OpenEmail()
    {
        emailWindow.SetActive(true);
        readingEmail.SetActive(true);
        typingEmail.SetActive(false);
    }
}
