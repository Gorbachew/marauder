using UnityEngine;
using UnityEngine.EventSystems;

public class BlockButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    UI ui;

    private void Awake()
    {
        ui = transform.GetComponentInParent<UI>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ui.BtnBlockOnClick(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ui.BtnBlockOnClick(false);
    }
}
