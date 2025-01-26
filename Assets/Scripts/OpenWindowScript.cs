using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OpenWindowScript : MonoBehaviour
{
    [SerializeField] GameObject hideBars;
    [SerializeField] GameObject textBody;
    [SerializeField] GameObject readText;

    public void OpenWindow()
    {
        textBody.SetActive(true);
        hideBars.SetActive(false);
        readText.SetActive(false);
    }
}
