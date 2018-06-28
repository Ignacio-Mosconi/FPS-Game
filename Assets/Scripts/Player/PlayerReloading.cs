using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReloading : MonoBehaviour
{
    [SerializeField] int magSize;
    [SerializeField] int ammoLeft;
    int bulletsInMag;

    void Awake()
    {
        bulletsInMag = magSize;
    }

    void Update()
    {
        if (Input.GetButtonDown("Reload") && bulletsInMag < magSize + 1)
        {
            Reload();
            Debug.Log(bulletsInMag);
        }
    }

    void Reload()
    {
        if (ammoLeft > magSize)
        {
            if (bulletsInMag > 0)
                bulletsInMag = magSize + 1;
            else
                bulletsInMag = magSize;
            ammoLeft -= magSize;
        }
        else
        {
            if (ammoLeft > 0)
            {
                bulletsInMag = ammoLeft;
                ammoLeft = 0;
            }
        }
    }

    public int BulletsInMag
    {
        get { return bulletsInMag; }
        set { bulletsInMag = value; }
    }
}
