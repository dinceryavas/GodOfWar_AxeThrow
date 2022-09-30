using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;

    Rigidbody rb;
    public Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        if(verticalInput!=0||horizontalInput!=0)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }
        
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetBool("Preparing", true);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            anim.SetTrigger("Throw");
        }
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10, ForceMode.Force);
    }
}
