using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerReloading))]

public class PlayerShooting : MonoBehaviour 
{
    [SerializeField] float damage;
    [SerializeField] float range;
    [SerializeField] float fireRate;
    [SerializeField] float impactForce;
    [SerializeField] Camera fpsCamera;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] UnityEvent onShot;
    PlayerReloading playerReloading;
    float nextFireTime = 0;

    void Awake()
    {
        playerReloading = GetComponent<PlayerReloading>();  
    }

    void Update() 
	{
		if (Input.GetButton("Fire1") && Time.time >= nextFireTime && playerReloading.BulletsInMag > 0)
        {
            nextFireTime = Time.time + 1 / fireRate;
            Shoot();
            onShot.Invoke();
        }
	}

    void Shoot()
    {
        muzzleFlash.Play();

        playerReloading.BulletsInMag--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Life targetLife = hit.transform.GetComponent<Life>();
            Rigidbody targetRigidbody = hit.transform.GetComponent<Rigidbody>();

            if (targetLife)
            {
                float damagePercentage = 1 - (hit.transform.position - transform.position).magnitude / range;
                targetLife.TakeDamage(damage * damagePercentage);
                Debug.Log((hit.transform.position - transform.position).magnitude);
                Debug.Log(damage * damagePercentage);
            }
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
