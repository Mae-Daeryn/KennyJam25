using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    float moveX;
    float moveZ;
    public Transform orientation;

    Vector3 moveDirection;

    Rigidbody rb;
    private Animator animator;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void Update()
    {
        WASDInput();
        transform.rotation = orientation.rotation;

    }

    private void WASDInput()
    {
        
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
    }


    private void MovePlayer()
    {
        Vector3 forward = Vector3.ProjectOnPlane(orientation.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(orientation.right, Vector3.up).normalized;

        moveDirection = forward * moveZ + right * moveX;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            rb.AddForce(moveDirection.normalized * (moveSpeed + 1) * 10f, ForceMode.Force);
            animator.SetFloat("Speed", 4);
        }
        else
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            animator.SetFloat("Speed", 1);
        }

        if (moveDirection == Vector3.zero)
        {
            animator.SetFloat("Speed", 0);
            
        }
    }
}
