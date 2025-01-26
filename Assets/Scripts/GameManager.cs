using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // static instance can be used by any other file
    public static GameManager gameInstance;

    [SerializeField]
    GameObject bubbleManager;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    bool[] hasPlayed = new bool[4];
    [SerializeField]
    TMP_Text timeText;

    public float totalGameTime;
    private float currentTime = 0;

    private bool gameOn = true;
    private bool gameWon = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (gameInstance == null)
        {
            gameInstance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.PlayOneShot(audioClips[0]);
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

            timeText.text = "4:5" + (7 + (int)((currentTime / totalGameTime) * 3)) + " PM";
            //Debug.Log((5 + (int)((currentTime / totalGameTime) * 5)));

            if(currentTime > 10.0f && !hasPlayed[1])
            {
                audioSource.PlayOneShot(audioClips[1]);
                hasPlayed[1] = true;
            }
            else if (currentTime > 60.0f && !hasPlayed[2])
            {
                audioSource.PlayOneShot(audioClips[2]);
                hasPlayed[2] = true;
            }
            else if(currentTime > 120.0f && !hasPlayed[3])
            {
                audioSource.PlayOneShot(audioClips[3]);
                hasPlayed[3] = true;
            }
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
