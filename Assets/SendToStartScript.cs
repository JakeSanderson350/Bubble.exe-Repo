using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SendToStartScript : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        StartCoroutine(BackToStart());
    }
    IEnumerator BackToStart()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("LoginScene");
    }
}
