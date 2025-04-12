using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    private UnityEvent onPressedButton;
    [SerializeField]
    private UnityEvent onReleasedButton;

    public void OnPointerDown(PointerEventData eventData)
    {
        onPressedButton?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onReleasedButton?.Invoke();
    }
}
