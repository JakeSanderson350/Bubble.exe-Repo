using UnityEngine;

public class OpenFilesWindowScript : MonoBehaviour
{
    [SerializeField] GameObject fileWindow;

    public void OpenFileWindow()
    {
        if (TaskManagerScript.taskManagerInstance.taskComplete[0])
        {
            fileWindow.SetActive(true);
        }
    }
}
