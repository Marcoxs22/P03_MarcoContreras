using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;


public class Dash : MonoBehaviour
{
    [SerializeField]
    private float inactiveDuration = 2f;
    [SerializeField]
    private float duration = 1f;
    [SerializeField]
    private UnityEvent onDash;
    [SerializeField]
    private UnityEvent onStopDash;
    private bool canDash = true;
    private bool isDashing;
    public bool IsDashing { get => isDashing; }
    private bool dashEnabled = true;

 

    public void SetDashEnabled(bool enabled)
    {
        dashEnabled = enabled;
    }

    public void DashAction()
    {
        if(!isDashing && canDash)
        {
            canDash = false;
            onDash?.Invoke();
            SoundManager.instance.Play("Dash");
            isDashing = true;
            Invoke(nameof(StopDash), duration);
        }
    }

    private void StopDash()
    {
        onStopDash?.Invoke();
        isDashing = false;
        Invoke(nameof(EnableDash), inactiveDuration);
    }

    private void EnableDash()
    {
        canDash = true;
        
    }

  
}
