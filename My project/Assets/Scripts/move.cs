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

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
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


    }

    private void WASDInput()
    {
        
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
    }


    private void MovePlayer()
    {
        moveDirection = orientation.forward * moveZ + orientation.right * moveX;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
