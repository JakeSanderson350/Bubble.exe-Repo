using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBarScript : MonoBehaviour
{
    public GameObject loadingWindow;
    public Image[] loadPoints;

    [SerializeField] float currentload = 0;
    [SerializeField] float loadspeedmultiplier = 5f;
   
    void Update()
    {
        float lerpSpeed = 3f * Time.deltaTime;

        if (currentload < 200)
        {
            currentload += (loadspeedmultiplier * Time.deltaTime);
        }

        if (currentload > 95 && currentload <= 105)
        {
            loadspeedmultiplier = 0.5f;
        }
        else if (currentload > 105)
        {
            loadspeedmultiplier = 15;
        }

        LoadingBarFiller();
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
}
