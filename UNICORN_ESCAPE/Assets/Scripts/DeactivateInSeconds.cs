using UnityEngine;
using UnityEngine.Events;

public class DeactivateInSeconds : MonoBehaviour
{
    [SerializeField]
    private float secondsToDeactivate = 5f;
    public UnityEvent<GameObject> onDeactivate;

    private void OnEnable()
    {
        Invoke("DeactivateObject", secondsToDeactivate);
    }

    private void DeactivateObject()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        onDeactivate?.Invoke(gameObject);
    }
}
