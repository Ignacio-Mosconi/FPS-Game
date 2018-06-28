using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour 
{
    [SerializeField] Image crosshair;
    [SerializeField] PlayerAnimation playerAnimation;
    [SerializeField] PlayerShooting playerShooting;

    void Awake() 
	{
        playerAnimation.OnShootingEnabledToggle.AddListener(CrosshairEnabledToggle);
	}

    void CrosshairEnabledToggle()
    {
        crosshair.enabled = playerShooting.enabled;
    }
}
