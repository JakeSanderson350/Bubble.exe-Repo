using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerButton : MonoBehaviour
{
    public int health = 5;

    private int healthCounter;

    public GameObject screenHitOBJ;
    public Image screenHit;
    private float alpha;

    private bool isLerping = false;
    private float lerpCounter = 0.0f;

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
            //show screenhit
            isLerping = true;
            StartCoroutine(Flash());

            if ( healthCounter <= 0)
            {
                GameManager.gameInstance.powerButtonHit();
            }
            
        }
    }

    private void Update()
    {
        if(isLerping)
        {
            lerpCounter += Time.deltaTime * 2;
        }
    }

    IEnumerator Flash()
    {
        screenHitOBJ.SetActive(true);
        screenHit.color = new Vector4(screenHit.color.r, screenHit.color.g, screenHit.color.b, alpha);
        alpha = Mathf.Lerp(212, 1f, lerpCounter);

        yield return new WaitForSeconds(0.2f);
        screenHitOBJ.SetActive(false);

        isLerping = false;
        lerpCounter = 0.0f;
    }
}
