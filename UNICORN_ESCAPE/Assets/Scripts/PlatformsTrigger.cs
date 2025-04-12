using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlatformsTrigger : MonoBehaviour
{
   [SerializeField]
   private UnityEvent onPlatformTriggered;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DeadZone"))
        {
            other.gameObject.SetActive(false);
            onPlatformTriggered?.Invoke();
        }
    }
}
