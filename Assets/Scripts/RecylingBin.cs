using UnityEngine;
using UnityEngine.EventSystems;

public class RecylingBin : MonoBehaviour, IDropHandler
{
    [SerializeField]
    GameObject appPrefab;

    [SerializeField]
    Canvas canvas;
    public static Canvas canvasForIcons;

    private GameObject trashIcon;
    private GameObject[] trashableList;

    private bool screenCleaned = false;

    public Vector2 screenSize;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            trashIcon = eventData.pointerDrag;
            if (trashIcon.tag == "trashable")
            {
                Destroy(trashIcon);
            }
            
        }
    }

    private void Awake()
    {
        canvasForIcons = canvas;
    }

    private void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            spawnApp();
        }
    }

    private void Update()
    {
        trashableList = GameObject.FindGameObjectsWithTag("trashable");

        if (!screenCleaned && trashableList.Length < 1)
        {
            TaskManagerScript.taskManagerInstance.Task1Complete();
            screenCleaned = true;
        }
    }

    private void spawnApp()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-screenSize.x, screenSize.x), Random.Range(-screenSize.y, screenSize.y), 0);

        Instantiate(appPrefab, spawnPos, Quaternion.identity, canvas.transform);
    }

    public static Canvas getCanvas()
    {
        return canvasForIcons;
    }
}
