using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private Transform goalPosRot;

    void Start() {
        cam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate() {
        if (goalPosRot == null) {return;}
        UpdatePosition();
        UpdateRotation();
    }

    private void UpdatePosition() {
        transform.position = Vector3.Lerp(transform.position, goalPosRot.position, 0.1f); 
    }

    private void UpdateRotation() {
        transform.rotation = Quaternion.Lerp(transform.rotation, goalPosRot.rotation, 0.1f); 
    }
}
