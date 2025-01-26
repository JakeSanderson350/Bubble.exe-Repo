using UnityEngine;

public class ExitFileWindowScript : MonoBehaviour
{
    [SerializeField] GameObject fileWindow;

    public void QuitFileWindow()
    {
        fileWindow.SetActive(false);
    }
}
