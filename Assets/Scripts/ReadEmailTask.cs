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

    private string[] emailSubjects = { "Balls", "yuh", "gagahagahgagah", "Ice Cold", "Seeyuhh", "Bubble ty shi" };
    //private string[] emailSubjectsTmp;
    private string[] emailMessages = { "You don't know ball", "Yuhhhhhh. GET ME HYPE!!!", "gagahagahgagahghahghahhahahghhhagahghahhahaghahaghahghga", "3 2 1 CCOOOOOLLLL", "Different day\r\nI just be stylin', it's hard to sleep (schyeah)\r\nShe never made it hard for me (schyeah)\r\nI can't trust my eyes, like, how do I see?\r\nI'm in the high, uh, she's in the heat, yeah\r\nTell me why? And, for what?\r\nAlways prepared, 'cause I never know what\r\nShe wait at all of my shows, she want me to sign her butt, yeah, uh", "Bubbles YIPPEEEEEE :D" };

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

            //emailSubjectsTmp = new string[emailSubjects.Length];
            //for(int i = 0; i < emailSubjectsTmp.Length; i++)
            //{
            //    emailSubjectsTmp[i] = emailSubjects[i].ToString();
            //}

            shuffleText();

            for (int i = 0; i < emailSubjects.Length; i++)
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
            //couldn't be opened to send email if it was set inactive
            //ParentObj.SetActive(false);
            //Let manager know
            TaskManagerScript.taskManagerInstance.Task2Complete();
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
