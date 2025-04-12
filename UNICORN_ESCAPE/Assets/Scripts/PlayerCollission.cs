using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollission : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onPlayerLose;
    [SerializeField]
    private UnityEvent<Transform> onObstacleDestroyed;
    [SerializeField]
    private UnityEvent<Transform> onCollisionDie;
    [SerializeField]
    private UnityEvent onCoinCollected;
    private Dash dash;

    private int obstacleCollisions = 0; // Contador de colisiones con obst�culos


    private void Start()
    {
        dash = GetComponent<Dash>();   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (dash.IsDashing)
            {
                onObstacleDestroyed?.Invoke(transform);
                Destroy(collision.gameObject);
            }
            else
            {
                onCollisionDie?.Invoke(transform);
                onPlayerLose?.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DeadZone"))
        {
            onCollisionDie?.Invoke(transform);
            onPlayerLose?.Invoke();
            SoundManager.instance.Play("smash");
        }
        else if(other.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            onCoinCollected?.Invoke();
        }
    }
}
