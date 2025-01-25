using UnityEngine;
using TMPro;

public class DownloadFileTask : MonoBehaviour
{
    [SerializeField]
    TMP_Text buttonText;

    [SerializeField]
    GameObject loadingBar;

    private bool isDownloading = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonText.text = "Download";

        loadingBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startDownload()
    {
        if (!isDownloading)
        {
            isDownloading = true;
            loadingBar.SetActive(true);
        }
    }
}
