using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // static instance can be used by any other file
    public static GameManager gameInstance;

    [SerializeField]
    GameObject bubbleManager;

    [SerializeField]
    TMP_Text timeText;

    public float totalGameTime;
    private float currentTime = 0;

    private bool gameOn = true;
    private bool gameWon = false;

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
        // If all tasks done player wins
        if (TaskManagerScript.taskManagerInstance.allTasksDone())
        {
            gameWon = true;
            gameOver();
        }
    }

    private void FixedUpdate()
    {
        if (gameOn)
        {
            currentTime += Time.fixedDeltaTime;

            timeText.text = "4:5" + (5 + (int)((currentTime / totalGameTime) * 5)) + " PM";
            Debug.Log((5 + (int)((currentTime / totalGameTime) * 5)));

            if (currentTime > totalGameTime)
            {
                gameOn = false;
                gameWon = false;
                gameOver();
                Debug.Log("ran out of Time");
            }
        }
    }

    public void turnOnBubbles()
    {
        bubbleManager.SetActive(true);
    }

    public void powerButtonHit()
    {
        gameWon = false;
        gameOver();
       
    }

    private void gameOver()
    {
        if (gameWon)
        {
            //SceneManager.LoadScene(1);
            Debug.Log("You da goat");
        }
        else
        {
            //SceneManager.LoadScene(1);
            Debug.Log("Ur asss");
        }
    }
}
