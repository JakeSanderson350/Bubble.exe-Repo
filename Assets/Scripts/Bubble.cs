using System.Security.Cryptography;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    public Animator animator;
    public AudioSource audioSource;
    
    public Vector3 powerButtonPos;

    private Vector2 forceAdded;

    // Bubble Position variables
    [SerializeField]
    Transform bubbleTransform;
    private Vector3 bubbleLocalPos;
    private float timeOffset;

    private float currentTime;

    [SerializeField]
    CircleCollider2D circleCollider;

    public bool isMovingToPower = false;
    private int moveCounter = 15;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        forceAdded = initForce();
        Debug.DrawLine(transform.position, transform.position + (Vector3)forceAdded);
        rb.AddForce(forceAdded);

        timeOffset = Random.Range(0.0f, 5.0f);

        //circleCollider.enabled = false;
    }

    private void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;

        updateBubblePos();
        pushBubble();
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Play Animation
            animator.SetBool("hasPopped", true);
            audioSource.Play();
            Invoke("popBubble", 0.4f);
        }
    }

    private Vector2 initForce()
    {
        Vector2 toCenter = (Vector2)(Vector3.zero - transform.position);

        toCenter.Normalize();

        int forceMag = Random.Range(20, 30);
        
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
        // Every 5 seconds push bubble somewhere
        if (currentTime < 10.0f && (Mathf.Round(currentTime * 100.0f) / 100.0f) % 5 == 0)
        {
            float turnDegree = Random.Range(-45.0f, 45.0f);
            float turnRadian = turnDegree * Mathf.Deg2Rad;

            forceAdded = rotate(forceAdded, turnRadian);
            forceAdded = forceAdded.normalized * Random.Range(5, 15);
            Debug.DrawLine(transform.position, transform.position + (Vector3)forceAdded);
            rb.AddForce(forceAdded);
        }

        // After 16 seconds bubble moves toward button
        if ((Mathf.Round(currentTime * 100.0f) / 100.0f) % 16 == 0)
        {
            isMovingToPower = true;
            //gameObject.tag = "MovingToPower";
            transform.position = new Vector3(transform.position.x, transform.position.y, -1.0f);
            circleCollider.enabled = true;
        }

        if (isMovingToPower && moveCounter > 0)
        {
            forceAdded = powerButtonPos - transform.position;
            Debug.DrawLine(transform.position, transform.position + (Vector3)forceAdded);
            rb.AddForce(forceAdded);

            moveCounter--;
        }

        // After 20 seconds destroy bubble
        if ((Mathf.Round(currentTime * 100.0f) / 100.0f) % 20 == 0)
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

    private void popBubble()
    {
        Destroy(gameObject);
    }
}
