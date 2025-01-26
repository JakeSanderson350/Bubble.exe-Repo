using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBarScript : MonoBehaviour
{
    public GameObject loadingWindow;
    public GameObject loginWindow;
    public Image[] loadPoints;  
    public AudioSource audioSource;
    private bool playAudio = true;

    [SerializeField] float currentload = 0;
    [SerializeField] float loadspeedmultiplier = 0f;

    bool isLoading = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        loadingWindow.SetActive(false);
    }
    void Update()
    {
        float lerpSpeed = 3f * Time.deltaTime;

        if (isLoading)
        {
            currentload += (loadspeedmultiplier * Time.deltaTime);
        }
        if (currentload < 200)
        {
            
            loadspeedmultiplier = 5;
        }

        if (currentload > 95 && currentload <= 105)
        {
            
            loadspeedmultiplier = 0.5f;
            PlayAudio();
        }
        else if (currentload > 105)
        {
            loadspeedmultiplier = 15;
        }

        LoadingBarFiller();

        //checks if the loading bar is finished
        if (currentload >= 200)
        {
            isLoading = false;
            loadingWindow.SetActive(false);
            loadDesktopScene();
        }
    }
    public void turnOnLoadingBar()
    {
        isLoading = true;
        loadingWindow.SetActive(true);
        loginWindow.SetActive(false);
    }
   
    void LoadingBarFiller()
    {
        //enables load point images 
        for (int i = 0; i < loadPoints.Length; i++)
        {
            loadPoints[i].enabled = !DisplayLoadPoint(currentload, i);
        }
    }

    bool DisplayLoadPoint(float _load, int loadPointNumber)
    {
        return ((loadPointNumber * 10) >= _load);
    }

    void loadDesktopScene()
    {
        SceneManager.LoadScene("DesktopScene");
    }

    void PlayAudio()
    {
        if (playAudio)
        {
            audioSource.Play();
            playAudio = false;
        }
    }
}
