using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerShooting))]

public class PlayerAnimation : MonoBehaviour 
{
    [SerializeField] UnityEvent onShootingEnabledToggle;
    Animator animator;
    CharacterController charController;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;

    void Awake()
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

        if (!jumping)
        {
            if (!playerShooting.enabled && normalizedVelocity < 0.6)
                EnableShooting();
            else
                if (playerShooting.enabled && normalizedVelocity >= 0.6)
                    DisableShooting();
        }
        else
            if (playerShooting.enabled)
                DisableShooting();

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

    void DisableShooting()
    {
        playerShooting.enabled = false;
        onShootingEnabledToggle.Invoke();
    }

    void EnableShooting()
    {
        playerShooting.enabled = true;
        onShootingEnabledToggle.Invoke();
    }

    public UnityEvent OnShootingEnabledToggle
    {
        get { return onShootingEnabledToggle; }
    }
}
