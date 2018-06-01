using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour 
{
    [SerializeField] private float movementSpeed;
    private CharacterController charController;

    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    void Update() 
	{
        Vector3 movement = new Vector3(0, 0, 0);

        float fwdMovement = Input.GetAxis("Vertical") * movementSpeed;
        float horMovement = Input.GetAxis("Horizontal") * movementSpeed;

        movement += transform.forward * fwdMovement + transform.right * horMovement;

        charController.Move(movement * Time.deltaTime);
	}
}
