using UnityEngine;
using TMPro;

public class TaskManagerScript : MonoBehaviour
{
    [Header("---------- TASKS ----------")]
    [SerializeField] TMP_Text task1;
    [SerializeField] TMP_Text task2;
    [SerializeField] TMP_Text task3;
    [SerializeField] TMP_Text task4;

    private AudioSource audioSource;

    public bool[] taskComplete;

    public static TaskManagerScript taskManagerInstance;

    private void Awake()
    {
        if (taskManagerInstance == null)
        {
            taskManagerInstance = this;
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        taskComplete = new bool[4];
    }
    private void Update()
    {
        
    }

    public void Task1Complete()
    {
        task1.fontStyle = FontStyles.Strikethrough | FontStyles.Bold;
        taskComplete[0] = true;

        //Start Bubbles
        GameManager.gameInstance.turnOnBubbles();
        audioSource.Play();
    }

    public void Task2Complete()
    {
        task2.fontStyle = FontStyles.Strikethrough | FontStyles.Bold;
        taskComplete[1] = true;
    }

    public void Task3Complete()
    {
        task3.fontStyle = FontStyles.Strikethrough | FontStyles.Bold;
        taskComplete[2] = true;
    }

    public void Task4Complete()
    {
        task4.fontStyle = FontStyles.Strikethrough | FontStyles.Bold;
        taskComplete[3] = true;
    }

    public bool allTasksDone()
    {
        foreach (bool isChecked in taskComplete)
        {
            if (!isChecked)
            {
                return false;
            }
        }
        return true;
    }
}
