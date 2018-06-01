using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform fpsCamera;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float verViewRange;
    private float verAngle = 0;

    private void Update()
    {
        float horRotation = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float verRotation = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        verAngle += verRotation;
        verAngle = Mathf.Clamp(verAngle, -verViewRange, verViewRange);

        fpsCamera.localEulerAngles = new Vector3(verAngle, 0, 0);
        transform.Rotate(0, horRotation, 0);
    }
}
