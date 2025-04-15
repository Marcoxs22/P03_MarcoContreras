using UnityEngine;

public class RunSpeed : MonoBehaviour
{
    [SerializeField]
    private float increaseValue = 0.1f;
    [SerializeField]
    private float initialSpeedValue = 1f;
    [SerializeField]
    private Animator characterAnimator;
    [SerializeField]
    private string animatorValueName = "RunSpeed";
    private float speedValue = 1f;
    private bool isRunning = false;


    public void StartRunSpeed()
    {
        speedValue = initialSpeedValue;
        isRunning = true;
    }

    public void StopRunSpeed()
    {
        isRunning = false;
    }

    private void Update()
    {
        if(isRunning)
        {
            speedValue += increaseValue * Time.deltaTime;
            characterAnimator.SetFloat(animatorValueName, speedValue);
        }
    }
}
