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

    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    void Update() 
	{
        verticalSpeed -= gravity * Time.deltaTime;

        Vector3 movement = new Vector3(0, 0, 0);

        float fwdMovement = Input.GetAxis("Vertical");
        float horMovement = Input.GetAxis("Horizontal");
        float speedMultiplier = (Input.GetButton("Forward") && Input.GetButton("Sprint")) ? 1.0f : 0.5f;

        Vector3 inputVector = new Vector3(horMovement, 0, fwdMovement);
        inputVector.Normalize();
        inputVector *= movementSpeed;

        movement += (transform.forward * inputVector.z + transform.right * inputVector.x) * speedMultiplier;
        movement += Vector3.up * verticalSpeed;

        charController.Move(movement * Time.deltaTime);

        if (charController.isGrounded)
            verticalSpeed = (Input.GetButton("Jump")) ? jumpingSpeed : 0;
        else
            if ((charController.collisionFlags & CollisionFlags.Above) != 0)
                verticalSpeed = 0;
    }

    public float MovementSpeed
    {
        get { return movementSpeed;}
    }

}
