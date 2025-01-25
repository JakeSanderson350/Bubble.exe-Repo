using UnityEngine;
using TMPro;

public class TaskManagerScript : MonoBehaviour
{
    [Header("---------- TASKS ----------")]
    [SerializeField] TMP_Text task1;
    [SerializeField] TMP_Text task2;
    [SerializeField] TMP_Text task3;
    [SerializeField] TMP_Text task4;

    private void Update()
    {
      
    }

    void Task1Complete()
    {
        task1.fontStyle = FontStyles.Strikethrough | FontStyles.Bold;
    }

    void Task2Complete()
    {
        task2.fontStyle = FontStyles.Strikethrough | FontStyles.Bold;
    }

    void Task3Complete()
    {
        task3.fontStyle = FontStyles.Strikethrough | FontStyles.Bold;
    }

    void Task4Complete()
    {
        task4.fontStyle = FontStyles.Strikethrough | FontStyles.Bold;
    }
}
