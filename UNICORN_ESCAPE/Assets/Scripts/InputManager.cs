using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onPressedKey;
    [SerializeField]
    private UnityEvent onReleasedKey;
    private void Update()
    {
        #if UNITY_EDITOR || UNITY_STANDALONE
         if(Input.GetKeyDown(KeyCode.Space))
         {
            onPressedKey?.Invoke();
         }   

         if(Input.GetKeyUp(KeyCode.Space))
         {
            onReleasedKey?.Invoke();
         }
        #endif
    }
}
