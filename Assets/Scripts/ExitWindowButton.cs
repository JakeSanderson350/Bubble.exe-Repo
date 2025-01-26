using UnityEngine;

public class ExitWindowButton : MonoBehaviour
{
    [SerializeField] GameObject window;
    [SerializeField] GameObject hideBars;
    [SerializeField] GameObject textBody;
    [SerializeField] GameObject readText;
    public void CloseWindow()
    {
        
        textBody.SetActive(false);
        hideBars.SetActive(true);
        readText.SetActive(false);

        window.SetActive(false);
    }
}
