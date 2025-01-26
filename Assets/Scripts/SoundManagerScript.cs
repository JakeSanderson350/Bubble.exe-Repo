using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundManagerScript : MonoBehaviour
{
    [Header("---------- SFX ----------")]
    [SerializeField] AudioClip[] sfxList;
    private AudioSource sfx;

    private void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            sfx.Play();
        }
    }
}
