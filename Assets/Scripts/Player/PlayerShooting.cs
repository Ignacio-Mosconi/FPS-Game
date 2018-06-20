using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour 
{
    [SerializeField] float damage;
    [SerializeField] float range;
    [SerializeField] float fireRate;
    [SerializeField] float impactForce;
    [SerializeField] Camera fpsCamera;
    [SerializeField] ParticleSystem muzzleFlash;
    PlayerMovement playerMovement;
    float nextFireTime = 0;

    void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    void Update() 
	{
        if (!playerMovement.IsJumping() && !playerMovement.IsSprinting())
		    if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
            {
                nextFireTime = Time.time + 1 / fireRate;
                Shoot();
            }
	}

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Damageable targetDamagable = hit.transform.GetComponent<Damageable>();
            Rigidbody targetRigidbody = hit.transform.GetComponent<Rigidbody>();

            if (targetDamagable)
                targetDamagable.TakeDamage(damage);
            if (targetRigidbody)
                targetRigidbody.AddForce(-hit.normal * impactForce);
        }
    }
}
