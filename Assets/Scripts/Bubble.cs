using System.Security.Cryptography;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    Transform powerButtonPos;

    private Vector2 forceAdded;

    // Bubble Position variables
    [SerializeField]
    Transform bubbleTransform;
    private Vector3 bubbleLocalPos;
    private float timeOffset;

    private float currentTime;

    [SerializeField]
    CircleCollider2D circleCollider;

    private bool isMovingToPower = false;
    private int moveCounter = 15;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        forceAdded = initForce();
        rb.AddForce(forceAdded);

        timeOffset = Random.Range(0.0f, 5.0f);

        circleCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        updateBubblePos();
    }

    private void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;

        pushBubble();
    }

    private Vector2 initForce()
    {
        Vector2 toCenter = (Vector2)(Vector3.zero - transform.position);

        toCenter.Normalize();

        int forceMag = Random.Range(5, 10);
        
        return toCenter * forceMag;
    }

    private void updateBubblePos()
    {
        float bubbleX = Mathf.Cos(Time.time + timeOffset) * 1.0f;
        float bubbleY = (Mathf.Sin(Time.time + timeOffset) * 0.5f) - 0.5f;

        bubbleLocalPos = new Vector3(bubbleX, bubbleY, 0.0f);

        bubbleTransform.localPosition = bubbleLocalPos;
    }

    private void pushBubble()
    {
        // Every 3 seconds push bubble somewhere
        if (currentTime < 10.0f && (Mathf.Round(currentTime * 100.0f) / 100.0f) % 3 == 0)
        {
            float turnDegree = Random.Range(-45.0f, 45.0f);
            float turnRadian = turnDegree * Mathf.Deg2Rad;

            forceAdded = rotate(forceAdded, turnRadian);
            Debug.DrawLine(transform.position, transform.position + (Vector3)forceAdded);
            rb.AddForce(forceAdded);
        }

        // After 10 seconds bubble moves toward button
        if ((Mathf.Round(currentTime * 100.0f) / 100.0f) % 10 == 0)
        {
            isMovingToPower = true;
            circleCollider.enabled = true;
        }

        if (isMovingToPower && moveCounter > 0)
        {
            forceAdded = powerButtonPos.position - transform.position;
            Debug.DrawLine(transform.position, transform.position + (Vector3)forceAdded);
            rb.AddForce(forceAdded);

            moveCounter--;
        }

        // After 15 seconds destroy bubble
        if ((Mathf.Round(currentTime * 100.0f) / 100.0f) % 15 == 0)
        {
            Destroy(gameObject);
        }
    }

    public static Vector2 rotate(Vector2 v, float delta)
    {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }
}
