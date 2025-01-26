using UnityEngine;

public class OpenNotePadScript : MonoBehaviour
{
    [SerializeField] GameObject notePad;
    public void OpenWindow()
    {
        notePad.transform.localScale = new Vector3(1.5392f, 1.5392f, 1.5392f);
    }
}
