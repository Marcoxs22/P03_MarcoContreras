using UnityEngine;
using UnityEngine.Events;
public class ObjectFromPool : MonoBehaviour
{
    public UnityEvent<GameObject> onDeactivate;
    
     private void OnDisable()
    {
        onDeactivate?.Invoke(gameObject);
    }
}
