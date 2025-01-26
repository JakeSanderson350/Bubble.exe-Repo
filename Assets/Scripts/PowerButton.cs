using UnityEngine;

public class PowerButton : MonoBehaviour
{
    public int health = 5;

    private int healthCounter;

    private void Start()
    {
        healthCounter = health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject bubble = collision.gameObject;

        if (bubble.transform.position.z < 0.0f)
        {
            Debug.Log("Button hit " + healthCounter);
            healthCounter--;

            if( healthCounter <= 0)
            {
                GameManager.gameInstance.powerButtonHit();
            }
            
        }
    }
}
