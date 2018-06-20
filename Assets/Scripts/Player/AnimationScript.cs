using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerShooting))]

public class AnimationScript : MonoBehaviour 
{
    Animator animator;
    CharacterController charController;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerShooting = GetComponent<PlayerShooting>();
        charController = GetComponentInParent<CharacterController>();
        playerMovement = GetComponentInParent<PlayerMovement>();

        playerShooting.OnShot.AddListener(HasShot);
    }

    void Update() 
	{
        Vector3 horVelocity = new Vector3(charController.velocity.x, 0, charController.velocity.z);
        float normalizedVelocity = horVelocity.magnitude / playerMovement.MovementSpeed;
        float verticalVelocity = charController.velocity.y;
        bool jumping = playerMovement.IsJumping();
        
        animator.SetFloat("Horizontal Velocity", normalizedVelocity, 0.2f, Time.deltaTime);
        animator.SetFloat("Vertical Velocity", verticalVelocity, 0.2f, Time.deltaTime);
        animator.SetBool("Is Jumping", jumping);
	}

    void HasShot()
    {
        animator.SetBool("Is Shooting", true);
        Invoke("IsNotShooting", 1 / playerShooting.FireRate);
    }

    void IsNotShooting()
    {
        animator.SetBool("Is Shooting", false);
    }
}
