using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Private
    Vector3 velocity;

    float xVal, zVal;
    bool isGrounded;

    // Public
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;

    public float speed = 12f;
    public float gravity = -12f;
    public float groundDistance = 0.8f;
    public float jumpHeight = 3f;
    
    
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        xVal = Input.GetAxis("Horizontal");
        zVal = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xVal + transform.forward * zVal;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
