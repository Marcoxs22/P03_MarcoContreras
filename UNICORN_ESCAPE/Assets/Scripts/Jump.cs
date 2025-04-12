using UnityEngine;
using UnityEngine.Events;

public class Jump : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private float maxJumpTime = 0.3f;
    [SerializeField]
    private float jumpBoost = 0.5f;
    [SerializeField]
    private int maxJumps = 2;
    private int jumps;
    private Rigidbody rb;
    private bool isGrounded;
    private bool isJumping;
    private float jumpTimeCounter;
    private bool buttonPressed;
    private bool canJump = true;
    [SerializeField]
    private UnityEvent _play;
    [SerializeField]
    private UnityEvent _onLand;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetCanJump(bool value)
    {
        canJump = value;
        RestartJumps();
        isGrounded = true;
    }
    private void RestartJumps()
    {
        jumps = maxJumps;
    }

    public void StartJump()
    {
        SoundManager.instance.Play("Jump");
        if (!canJump)
        {
            return;
        }
        buttonPressed = true;
        if(isGrounded || jumps > 0)
        {
            jumps --;
            isJumping = true;
            jumpTimeCounter = maxJumpTime;
            rb.linearVelocity = Vector3.up * jumpForce;
            isGrounded = false;
            _play?.Invoke();
        }
    }

    public void EndJump()
    {
        buttonPressed = false;
        isJumping = false;
    }

    private void FixedUpdate()
    {
        HandleJump();   
    }

    private void HandleJump()
    {
        if(buttonPressed && isJumping)
        {
            if(jumpTimeCounter > 0)
            {
                rb.linearVelocity = Vector3.up * (jumpForce * jumpBoost);
                jumpTimeCounter -= Time.fixedDeltaTime;
            }
            else
            {
               isJumping = false;
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            RestartJumps();
            isGrounded = true;
            _onLand?.Invoke();
        }        
    }
}
