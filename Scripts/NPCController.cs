using UnityEngine;

public class NPCController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    public float moveSpeed = 3f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Assuming you have a simple control mechanism (e.g., arrow keys or AI logic)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        rb.velocity = movement * moveSpeed;

        // Set the animation parameters based on movement
        if (movement.magnitude > 0.1f)
        {
            animator.SetBool("IsWalking", true);
            // Adjust the rotation of the NPC to face the movement direction
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime * 500f);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
