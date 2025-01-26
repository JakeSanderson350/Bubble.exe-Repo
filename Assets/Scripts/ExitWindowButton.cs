using UnityEngine;

public class ExitWindowButton : MonoBehaviour
{
    [SerializeField] GameObject window;
   public void CloseWindow()
    {
        window.SetActive(false);
    }
}
