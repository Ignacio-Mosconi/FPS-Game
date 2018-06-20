using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AnimationScript : MonoBehaviour 
{
    Animator animator;
    CharacterController charController;
    PlayerMovement playerMovement;

    void Start()
    {
        animator = GetComponent<Animator>();
        charController = GetComponentInParent<CharacterController>();
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    void Update() 
	{
        Vector3 horVelocity = new Vector3(charController.velocity.x, 0, charController.velocity.z);
        float normalizedVelocity = horVelocity.magnitude / playerMovement.MovementSpeed;
        float verticalVelocity = charController.velocity.y;
        bool jumping = !charController.isGrounded;

        animator.SetFloat("Horizontal Velocity", normalizedVelocity, 0.2f, Time.deltaTime);
        animator.SetFloat("Vertical Velocity", verticalVelocity, 0.2f, Time.deltaTime);
        animator.SetBool("Is Jumping", jumping);
	}
}
