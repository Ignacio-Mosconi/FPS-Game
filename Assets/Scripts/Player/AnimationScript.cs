using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AnimationScript : MonoBehaviour 
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update() 
	{
        bool moving = (Input.GetButton("Vertical") || Input.GetButton("Horizontal")) ? true : false;
        animator.SetBool("Walking", moving);
	}
}
