using UnityEngine;

public class ExitNotepadScript : MonoBehaviour
{
    [SerializeField] GameObject window;
    public void CloseWindow()
    {
        window.transform.localScale = new Vector3(0, 0, 0);
    }
}
