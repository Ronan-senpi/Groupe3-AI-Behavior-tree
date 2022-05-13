using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] private GameObject cameraHolder;
    [SerializeField] private float mouseSpeed, walkSpeed, sprintSpeed, jumpForce, smoothTime;


    private float verticalLookRotation;
    public bool Grounded { get; set; }
    private Vector3 smoothMoveVelocity;
    private Vector3 moveAmount;

    private Rigidbody rb;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {

        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }

    void Update()
    {
        Look();
        MoveControls();
        Jump();
    }

    private void Jump()
    {
        if (Input.GetButton("Jump") && Grounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }

    private void MoveControls()
    {
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        moveAmount = Vector3.SmoothDamp(moveAmount,
            moveDir * (Input.GetButton("Sprint") ? sprintSpeed : walkSpeed), //Sprint or walk
            ref smoothMoveVelocity,
            smoothTime);
    }

    void Look()
    {
        //Rotate Character
        transform.Rotate(Vector3.up * (Input.GetAxisRaw("Mouse X") * mouseSpeed));
        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSpeed;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }

}
