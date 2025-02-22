using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DownloadFileTask : MonoBehaviour
{
    [SerializeField]
    TMP_Text buttonText;

    [SerializeField]
    GameObject loadingBar;
    public GameObject downloadScreen;

    [SerializeField]
    GameObject ParentObj;

    [SerializeField]
    GameObject adManagerPrefab;
    GameObject adManagerInstance;

    private bool isDownloading = false;
    private bool isDownloaded = false;

    public AudioSource audioSource;
    bool hasPlayed = false;
    // Loading Bar variables
    [SerializeField] Image[] loadPoints;

    private float loadProgress = 0;
    private float loadSpeedMultiplier = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        buttonText.text = "Download";

        loadingBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Add to load progress
        if (isDownloading)
        {
            loadProgress += (loadSpeedMultiplier * Time.deltaTime);
        }

        if (loadProgress < 25)
        {
            loadSpeedMultiplier = 10.0f;
        }
        else if (loadProgress < 30)
        {
            loadSpeedMultiplier = 0.5f;
        }
        else if (loadProgress < 100)
        {
            loadSpeedMultiplier = 15.0f;
        }
        else if (loadProgress < 105)
        {
            if (!hasPlayed)
            {
                audioSource.Play();
                hasPlayed = true;
            }
            loadSpeedMultiplier = 0.5f;
        }
        else if (loadProgress < 200)
        {
            loadSpeedMultiplier = 15.0f;
        }

        LoadingBarFiller();

        if (loadProgress >= 200)
        {
            isDownloaded = true;
            isDownloading = false;

            buttonText.text = "Done";
            // Disable loadingBar and have completed icon
            //loadingBar.SetActive(false);
        }
    }

    private void LoadingBarFiller()
    {
        //enables load point images 
        for (int i = 0; i < loadPoints.Length; i++)
        {
            loadPoints[i].enabled = !DisplayLoadPoint(loadProgress, i);
        }
    }

    private bool DisplayLoadPoint(float _load, int loadPointNumber)
    {
        return ((loadPointNumber * 10) >= _load);
    }

    public void startDownload()
    {
        if (!isDownloading && !isDownloaded)
        {
            isDownloading = true;
            loadingBar.SetActive(true);
            downloadScreen.SetActive(true);
            loadSpeedMultiplier = 5.0f;

            // Start ad pop ups
            adManagerInstance = Instantiate(adManagerPrefab);
            adManagerInstance.SetActive(true);

            buttonText.text = "Close";
        }
    }

    public void closeDownload()
    {
        if (isDownloaded)
        {
            TaskManagerScript.taskManagerInstance.Task4Complete();
            //ParentObj.SetActive(false);
            downloadScreen.SetActive(false);
            
            adManagerPrefab.SetActive(false);
        }
    }
}
