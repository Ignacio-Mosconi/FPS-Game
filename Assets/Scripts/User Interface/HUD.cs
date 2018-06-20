using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour 
{
    [SerializeField] Image crosshair;
    [SerializeField] PlayerMovement playerMovement;

    void Update() 
	{
        crosshair.enabled = (playerMovement.IsSprinting() || playerMovement.IsJumping()) ? false : true;
	}
}
