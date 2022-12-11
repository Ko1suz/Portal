using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    Vector3 velocity;
    Rigidbody rb;
    bool isGrounded;

    public Transform ground;
    public float distance = 0.3f;
    public float speed;
    public float jumpHeight;
    public float gravity;
    public LayerMask mask;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Movment();
        Jump();
        GroundCheckAndGravity();
    }

    void Movment()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * speed * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    void GroundCheckAndGravity()
    {
        isGrounded = Physics.CheckSphere(ground.position, distance, mask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Portal"))
        {
            transform.position = other.gameObject.GetComponent<PortalTeleporterScript>().reciever.transform.position;
        }
    }
}
