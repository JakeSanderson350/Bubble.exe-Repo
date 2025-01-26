using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WidePopUpAds : MonoBehaviour
{
    [SerializeField] Button[] exitButtons;
    int currentButtonIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        exitButtons[0].gameObject.SetActive(true);
    }

    public void Buttons()
    {
        exitButtons[currentButtonIndex].gameObject.transform.localScale = new Vector3(0, 0, 0);
        exitButtons[currentButtonIndex + 1].gameObject.transform.localScale = new Vector3(0.7083201f, 0.7083201f, 0.7083201f);
        currentButtonIndex++;
    }

    public void ExitButton()
    {
        Destroy(gameObject);
    }
}
