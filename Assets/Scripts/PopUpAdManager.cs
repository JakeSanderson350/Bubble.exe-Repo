using UnityEngine;

public class PopUpAdManager : MonoBehaviour
{
    [SerializeField] GameObject[] adsList;
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] static public Canvas canvas;
    [SerializeField] float currentTime;
    public GameObject selectedSpawn;
   
    void Start()
    {
        canvas = FindFirstObjectByType<Canvas>();
        currentTime = 0f;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //keeping track of time
        currentTime += Time.fixedDeltaTime;
        
        spawnAd();
    }

    void spawnAd()
    {
        if ((Mathf.Round(currentTime * 100) / 100f) > 5)
        {
            if ((Mathf.Round(currentTime * 100) / 100f) % 1 == 0)
            {
                //select random spawnpoint
                selectedSpawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
                Vector3 spawnPos = selectedSpawn.transform.position;

                //spawn random ad at a random position near selected spawnpoint
                Vector3 randPos = new Vector3(Random.Range(-50, 110), Random.Range(100, -110), 0);
                Vector3 newPos = spawnPos + randPos;
                Instantiate(adsList[Random.Range(0, adsList.Length)], newPos, Quaternion.identity, canvas.transform);
                //Instantiate(adsList[0], newPos, Quaternion.identity, canvas.transform);
            }
        }
    }
}
