using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [Header("Movment")]
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCoolDown;
    public float airMultipler;
    public bool readyToJump;
    public KeyCode jumpKey = KeyCode.Space;
    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    public Transform orientation;
    Rigidbody rb;
    Vector3 moveDir;
    float horizontalInput;
    float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        orientation = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInputs();
        SpeedControl();
        //Handle Drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

    }
    private void FixedUpdate()
    {
        MovePlayer();
    }


    void MyInputs()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();

            Invoke(nameof(ResetJump), jumpCoolDown);
        }
    }

    void MovePlayer()
    {
        moveDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (grounded)
            rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveDir.normalized * moveSpeed * 10f * airMultipler, ForceMode.Force);
    }

    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void ResetJump()
    {
        readyToJump = true;
    }
}
