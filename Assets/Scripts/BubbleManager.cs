using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    [SerializeField]
    GameObject bubblePrefab;

    private float currentTime = 0;
    private int currentTimeInt = 2;
    private int numSpawns = 1;

    public Vector2 screenBounds;

    private void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;

        // Spawn every 2 seconds
        if (currentTime > currentTimeInt)
        {
            for (int i = 0; i < numSpawns; i++)
            {
                spawnBubble();
            }

            currentTimeInt += 2;
        }

        // Update difficulty every 15 seconds
        if ((Mathf.Round(currentTime * 100.0f) / 100.0f) % 15 == 0 && numSpawns <= 5)
        {
            numSpawns++;
        }
    }

    private void spawnBubble()
    {
        // Pick edge to spawn on
        // 0 = left, 1 = top, 2 = right, 3 = bottom
        int edge = Random.Range(0, 3);

        Vector3 spawnPos = Vector3.zero;

        switch (edge)
        {
            case 0:
                spawnPos.x = -screenBounds.x - 1;
                spawnPos.y = Random.Range(-screenBounds.y, screenBounds.y);
                break;
            case 1:
                spawnPos.x = Random.Range(-screenBounds.x, screenBounds.x);
                spawnPos.y = screenBounds.y + 1;
                break;
            case 2:
                spawnPos.x = screenBounds.x + 1;
                spawnPos.y = Random.Range(-screenBounds.y, screenBounds.y);
                break;
            case 3:
                spawnPos.x = Random.Range(-screenBounds.x, screenBounds.x);
                spawnPos.y = -screenBounds.y - 1;
                break;
            default:
                spawnPos.x = 0;
                spawnPos.y = screenBounds.y + 1;
                break;
        }

        GameObject newObj = Instantiate(bubblePrefab, spawnPos, Quaternion.identity);
    }
}
