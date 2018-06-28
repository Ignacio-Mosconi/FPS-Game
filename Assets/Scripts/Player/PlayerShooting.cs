using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShooting : MonoBehaviour 
{
    [SerializeField] float damage;
    [SerializeField] float range;
    [SerializeField] float fireRate;
    [SerializeField] float impactForce;
    [SerializeField] Camera fpsCamera;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] UnityEvent onShot;
    float nextFireTime = 0;

    void Update() 
	{
		if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1 / fireRate;
            Shoot();
            onShot.Invoke();
        }
	}

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Life targetDamagable = hit.transform.GetComponent<Life>();
            Rigidbody targetRigidbody = hit.transform.GetComponent<Rigidbody>();

            if (targetDamagable)
                targetDamagable.TakeDamage(damage);
            if (targetRigidbody)
                targetRigidbody.AddForce(-hit.normal * impactForce);
        }
    }

    public float FireRate
    {
        get { return fireRate; }
    }

    public UnityEvent OnShot
    {
        get { return onShot; }
    }
}
