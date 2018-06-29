using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour 
{
    [SerializeField] Image crosshair;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] PlayerAnimation playerAnimation;
    [SerializeField] PlayerShooting playerShooting;
    [SerializeField] PlayerReloading playerReloading;

    void Awake() 
	{
        playerAnimation.OnShootingEnabledToggle.AddListener(CrosshairEnabledToggle);
        playerReloading.OnAmmoChange.AddListener(ChangeAmmoDisplay);
	}

    void CrosshairEnabledToggle()
    {
        crosshair.enabled = playerShooting.enabled;
    }

    void ChangeAmmoDisplay()
    {
        string bulletsInMag = playerReloading.BulletsInMag.ToString();
        string ammoLeft = playerReloading.AmmoLeft.ToString();

        ammoText.text = bulletsInMag + "/" + ammoLeft;
    }
}
