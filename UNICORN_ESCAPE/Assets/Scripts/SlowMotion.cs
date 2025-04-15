using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    [SerializeField]
    private float slowMotionFactor = 0.1f;

    public void StartSlowMotion()
    {
        Time.timeScale = slowMotionFactor;
    } 

    public void StopSlowMotion()
    {
        Time.timeScale = 1f;
    }
}
