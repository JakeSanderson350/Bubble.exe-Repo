using UnityEditor;
using UnityEngine;

public class SmallPopUpAds : MonoBehaviour
{
    [SerializeField] GameObject ExtraAds;
    Vector3 originalPos;
    Transform CanvasTransform { get { return PopUpAdManager.canvas.transform; } }
    void Start()
    {
        //store position
        originalPos = gameObject.transform.position;
        //spawn 2 extra ads
        //SpawnExtraAds();
    }

    public void ExitAd()
    {
        Destroy(gameObject);
    }

    void SpawnExtraAds()
    {
        for (int i = 0; i < 2; i++)
        {
            Vector3 randPos = new Vector3(Random.Range(-50, 110), Random.Range(100, -110), 0);
            Vector3 newPos = originalPos + randPos;
            Instantiate(ExtraAds, newPos, Quaternion.identity, CanvasTransform);
        }
    }
}
