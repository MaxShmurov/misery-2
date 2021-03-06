using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    public float speed = 5;
    public Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 2;

    public Joystick joystick;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    bool isGrounded;

    public float speedIncreasePerPoint = 0.1f;

    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }



    // Update is called once per frame
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        horizontalInput = joystick.Horizontal;

        if (isGrounded)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }


        if (transform.position.y < -5)
        {
            Die();
        }
    }

    public void Die ()
    {
        alive = false;

        Invoke("Restart", 2);
      
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump()
    {
       float height = GetComponent<Collider>().bounds.size.y;
       bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        if (!isGrounded)
        {
            return;
        }
        rb.AddForce(Vector3.up * jumpForce);

    }
}
