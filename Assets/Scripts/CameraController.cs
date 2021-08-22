using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = .5f;
    public float mouseY;
    public float mouseX;
    public float minY = -80f;
    public float maxY = 80f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        transform.rotation = Quaternion.identity;
    }

    void Update()
    {
        Debug.Log(transform.rotation.eulerAngles.z);
        LockedRotation();
    }

    void LockedRotation()
    {
        mouseY += Input.GetAxis("Mouse Y") * sensitivity * 10;
        mouseY = Mathf.Clamp(mouseY, minY, maxY);

        mouseX += Input.GetAxis("Mouse X") * sensitivity * 10;

        transform.localEulerAngles = new Vector3(-mouseY, transform.localEulerAngles.y, transform.localEulerAngles.z);
        var parent = transform.parent.transform;
        parent.localEulerAngles = new Vector3(parent.localEulerAngles.x, mouseX, parent.localEulerAngles.z);
    }
}
