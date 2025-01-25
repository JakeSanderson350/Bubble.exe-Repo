using UnityEngine;

public class OpenNotePadScript : MonoBehaviour
{
    [SerializeField] GameObject notePad;
    public void OpenWindow()
    {
        notePad.SetActive(true);
    }
}
