using UnityEngine;
using TMPro;
using static UnityEditor.ShaderData;

public class SendEmailTask : MonoBehaviour
{
    [SerializeField]
    TMP_Text emailText;

    [SerializeField]
    GameObject ParentObj;

    private int emailMessageIndex;
    private string[] emailMessage = { "Hey Boss,\r\n\r\n" +
                    "Here are the files you asked for. Sorry I’m getting them to you so late. Jake (my dog) had a emergency and I had to take him to the vet. He’s fine now though.\r\n\r\n" +
                    "If you need anything further, please hesitate to contact me. \r\n\r\n" +
                    "With room temperature regards, \r\n\r\nEmployee No. 4\r\n" };

    private int numCharacters, currentChar;

    private bool emailDone = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Pick message and get number of chars in message
        emailMessageIndex = Random.Range(0, emailMessage.Length);
        numCharacters = emailMessage[emailMessageIndex].Length;
        currentChar = 0;

        emailText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && currentChar < numCharacters)
        {
            emailText.text += emailMessage[emailMessageIndex][currentChar];
            currentChar++;
        }

        else if (currentChar == numCharacters)
        {
            emailDone = true;
        }
    }

    public void sendEmail()
    {
        if (emailDone)
        {
            emailText.text = "Email Sent!";
            TaskManagerScript.taskManagerInstance.Task3Complete();

            Invoke("closeWindow", 2.0f);
        }
    }

    private void closeWindow()
    {
        ParentObj.SetActive(false);
        // Let manager know
    }
}
