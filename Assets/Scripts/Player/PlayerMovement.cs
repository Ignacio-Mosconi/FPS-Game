using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour 
{
    [SerializeField] float movementSpeed;
    CharacterController charController;

    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    void Update() 
	{
        Vector3 movement = new Vector3(0, 0, 0);

        float fwdMovement = Input.GetAxis("Vertical");
        float horMovement = Input.GetAxis("Horizontal");
        float speedMultiplier = (Input.GetButton("Forward") && Input.GetButton("Sprint")) ? 1.0f : 0.5f;

        Vector3 inputVector = new Vector3(horMovement, 0, fwdMovement);
        inputVector.Normalize();
        inputVector *= movementSpeed;

        movement += (transform.forward * inputVector.z + transform.right * inputVector.x) * speedMultiplier;

        charController.Move(movement * Time.deltaTime);
	}

    public float MovementSpeed
    {
        get { return movementSpeed;}
    }

}
