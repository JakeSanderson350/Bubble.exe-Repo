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
       exitButtons[currentButtonIndex].gameObject.SetActive(false);
       exitButtons[currentButtonIndex+1].gameObject.SetActive(true);
        currentButtonIndex++;
    }

    public void ExitButton()
    {
        Destroy(gameObject);
    }    
}
