using UnityEngine;
using UnityEngine.Events;

public class DeviceDetector : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onDesktop;
    [SerializeField]
    private UnityEvent onMobile;

    private void Start()
    {
        if (Application.isMobilePlatform)
        {
            onMobile?.Invoke();
        }
        else
        {
            onDesktop?.Invoke();
        }
    }
}