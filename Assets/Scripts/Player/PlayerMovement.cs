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

        float fwdMovement = Input.GetAxis("Vertical") * movementSpeed;
        float horMovement = Input.GetAxis("Horizontal") * movementSpeed;

        float speedMultiplier = (Input.GetButton("Forward") && Input.GetButton("Sprint")) ? 1.0f : 0.7f;

        movement += (transform.forward * fwdMovement + transform.right * horMovement) * speedMultiplier;

        charController.Move(movement * Time.deltaTime);
	}

    public float MovementSpeed
    {
        get { return movementSpeed; }
    }

}
