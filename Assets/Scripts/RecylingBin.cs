using UnityEngine;
using UnityEngine.EventSystems;

public class RecylingBin : MonoBehaviour, IDropHandler
{
    private GameObject trashIcon;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            trashIcon = eventData.pointerDrag;
            if (trashIcon.tag == "trashable")
            {
                Destroy(trashIcon);
            }
            
        }
    }
}
