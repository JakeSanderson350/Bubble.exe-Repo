using UnityEngine;

public class GameManager : MonoBehaviour
{
    // static instance can be used by any other file
    public static GameManager gameInstance;

    [SerializeField]
    GameObject bubbleManager;

    public float totalGameTime;
    private float currentTime = 0;

    private bool gameOver = false;

    private void Awake()
    {
        if (gameInstance == null)
        {
            gameInstance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bubbleManager.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;

        if (currentTime > totalGameTime)
        {
            gameOver = true;
        }
    }

    public void turnOnBubbles()
    {
        bubbleManager.SetActive(true);
    }
}
