using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TypingScript : MonoBehaviour
{
    public GameObject loginWindow;
    [SerializeField] TMP_Text password;
    [SerializeField] string pass;
    [SerializeField] string correctPassword = "**********";

    private void Start()
    {
        password.text = "";
        pass = "";
    }
    private void Update()
    {
       if (Input.anyKeyDown && pass.Length <= 10)
        {
            password.text += "*";
            pass += "*";
        }
    }

    public void OKButton()
    {
        if (pass == correctPassword)
        {
            loginWindow.SetActive(false);
        }
    }
}
