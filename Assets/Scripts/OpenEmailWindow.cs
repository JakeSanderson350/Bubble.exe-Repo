using UnityEngine;

public class OpenEmailWindow : MonoBehaviour
{
    [SerializeField] GameObject emailWindow;
    [SerializeField] GameObject typingEmail;
    [SerializeField] GameObject readingEmail;

    public void OpenEmail()
    {
        if (TaskManagerScript.taskManagerInstance.taskComplete[0])
        {
            emailWindow.SetActive(true);
            readingEmail.SetActive(true);
            typingEmail.SetActive(false);
        }
    }
}
