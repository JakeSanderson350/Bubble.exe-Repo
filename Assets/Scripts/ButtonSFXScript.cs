using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSFXScript : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");

    }
}
