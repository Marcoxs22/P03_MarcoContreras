using UnityEngine;
using UnityEngine.Events;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onStartGame;
    
    
    private void Start()
    {
        onStartGame?.Invoke();  
    }
    public void ShowScreen(GameObject screen)
    {
        screen.SetActive(true);
    }

    public void HideScreen(GameObject screen)
    {
        screen.SetActive(false);
    }

  

}
