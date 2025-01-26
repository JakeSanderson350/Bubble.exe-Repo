using UnityEngine;

public class OpenFilesWindowScript : MonoBehaviour
{
    [SerializeField] GameObject fileWindow;

    public void OpenFileWindow()
    {
        fileWindow.SetActive(true);
    }
}
