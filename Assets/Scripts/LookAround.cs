﻿using UnityEngine;

public class LookAround : MonoBehaviour
{
    [SerializeField] float headRotationLimit = 90f;
    [SerializeField] Transform cam;
    [SerializeField] float sensitivity;
    float headRotation = 0f;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime * -1f;
        transform.Rotate(0f, x, 0f);
        headRotation += y;
<<<<<<< HEAD
        headRotation = Mathf.Clamp(headRotation, -headRotationLimit, headRotationLimit);
        cam.localEulerAngles = new Vector3(headRotation, cam.localEulerAngles.y, cam.localEulerAngles.z);
=======
        cam.localEulerAngles = new Vector3(headRotation, 0f, 0f);
        headRotation += y;
        headRotation = Mathf.Clamp(headRotation, -headRotationLimit, headRotationLimit);
        cam.localEulerAngles = new Vector3(headRotation, 0f, 0f);
>>>>>>> 871a754... merged with character_movements
    }
}
