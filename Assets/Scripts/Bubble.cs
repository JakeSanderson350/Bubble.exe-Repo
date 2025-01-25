using System.Security.Cryptography;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    private Vector2 forceAdded;

    // Bubble Position variables
    [SerializeField]
    Transform bubbleTransform;
    private Vector3 bubbleLocalPos;
    private float timeOffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        forceAdded = initForce();
        rb.AddForce(forceAdded);

        timeOffset = Random.Range(0.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        updateBubblePos();
    }

    private void FixedUpdate()
    {
        
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
}
