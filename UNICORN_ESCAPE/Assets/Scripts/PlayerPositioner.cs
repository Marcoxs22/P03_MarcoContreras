using UnityEngine;
public class PlayerPositioner : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform startingPosition;


    public void SetPlayerPosition()
    {
       player.position = startingPosition.position;
       Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
       playerRigidbody.linearVelocity = Vector3.zero;
       playerRigidbody.angularVelocity = Vector3.zero;
    }
}
