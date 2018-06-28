using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour 
{
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpingSpeed;
    [SerializeField] float gravity;
    CharacterController charController;
    float verticalSpeed;
    float distanceToGround;
    bool jumpedWhileSprinting;

    void Awake()
    {
        charController = GetComponent<CharacterController>();
        distanceToGround = GetComponent<MeshFilter>().mesh.bounds.extents.y + 0.5f;
        jumpedWhileSprinting = false;
    }

    void Update() 
	{
        Vector3 movement = new Vector3(0, 0, 0);

        verticalSpeed -= gravity * Time.deltaTime;

        float fwdMovement = Input.GetAxis("Vertical");
        float horMovement = Input.GetAxis("Horizontal");
        float speedMultiplier = Input.GetButton("Forward") && Input.GetButton("Sprint") && !IsJumping() || jumpedWhileSprinting ?
            1.0f : 0.5f;

        Vector3 inputVector = new Vector3(horMovement, 0, fwdMovement);
        inputVector.Normalize();
        inputVector *= movementSpeed;

        movement += (transform.forward * inputVector.z + transform.right * inputVector.x) * speedMultiplier;
        movement += Vector3.up * verticalSpeed;

        charController.Move(movement * Time.deltaTime);

        if (charController.isGrounded)
        {
            verticalSpeed = (Input.GetButton("Jump")) ? jumpingSpeed : 0;
            jumpedWhileSprinting = Input.GetButton("Jump") && Input.GetButton("Forward") && Input.GetButton("Sprint") ? true : false;
        }
        else
            if ((charController.collisionFlags & CollisionFlags.Above) != 0)
                verticalSpeed = 0;
    }

    public bool IsJumping()
    {
        return !(Physics.Raycast(transform.position, -Vector3.up, distanceToGround));
    }

    public float MovementSpeed
    {
        get { return movementSpeed;}
    }
}
