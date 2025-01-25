using UnityEngine;

public class ExitWindowButton : MonoBehaviour
{
    [SerializeField] GameObject notePad;
   public void CloseWindow()
    {
        notePad.SetActive(false);
    }
}
