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

	void Update() 
	{
		if (Input.GetButton("Fire1"))
        {
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
                targetRigidbody.AddForce(0, 0, impactForce, ForceMode.Impulse);
        }
    }
}
