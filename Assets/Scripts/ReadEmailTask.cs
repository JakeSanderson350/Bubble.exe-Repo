using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReadEmailTask : MonoBehaviour
{
    [SerializeField]
    Button[] emailButtons;

    [SerializeField]
    TMP_Text[] emailHeaders;
    [SerializeField]
    TMP_Text emailText;

    [SerializeField]
    GameObject ParentObj;

    private bool[] emailIsChecked;

    private string[] emailSubjects = { "Balls", "yuh", "gagahagahgagah", "3 2 1 CCOOOOOLLLL", "Seeyuhh", "Bubble type shi", "ummmm" };
    private string[] emailMessages = { "Balls.....", "yuh.....", "gagahagahgagah.....", "3 2 1 CCOOOOOLLLL.....", "Seeyuhh.....", "Bubble type shi.....", "ummmm......" };

    private Dictionary<string, string> emailTable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Initializes all emails as unchecked
        emailIsChecked = new bool[emailButtons.Length];
        emailTable = new Dictionary<string, string>();

        if (emailHeaders.Length == emailSubjects.Length)
        {
            for (int i = 0; i < emailSubjects.Length; i++)
            {
                emailTable.Add(emailSubjects[i], emailMessages[i]);
            }

            shuffleText();
            for (int i = 0; i < emailButtons.Length; i++)
            {
                emailHeaders[i].text = emailSubjects[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (checkAllEmailsChecked())
        {
            ParentObj.SetActive(false);
            //Let manager know
        }
    }

    private bool checkAllEmailsChecked()
    {
        foreach (bool isChecked in emailIsChecked)
        {
            if (!isChecked)
            {
                return false;
            }
        }
        return true;
    }

    public void checkEmail(int emailIndex)
    {
        emailIsChecked[emailIndex] = true;

        emailText.text = emailTable[emailSubjects[emailIndex]];
        emailHeaders[emailIndex].text = "Checked";
    }

    private void shuffleText()
    {
        int index1, index2;

        for (int i = 0; i < 10; i++) 
        {
            index1 = Random.Range(0, emailSubjects.Length);
            index2 = Random.Range(0, emailSubjects.Length);

            swap(emailSubjects, index1, index2);
        }
    }

    public void swap(string[] arr, int i, int j)
    {
        string temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}
