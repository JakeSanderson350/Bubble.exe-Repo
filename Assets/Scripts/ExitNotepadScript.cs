using UnityEngine;

public class ExitNotepadScript : MonoBehaviour
{
    [SerializeField] GameObject window;
    public void CloseWindow()
    {
        window.SetActive(false);
    }
}
