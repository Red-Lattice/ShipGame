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

    void Update() {
        if (goalPosRot == null) {return;}
        UpdatePosition();
        UpdateRotation();
    }

    private void UpdatePosition() {
        transform.position = Vector3.Lerp(transform.position, goalPosRot.position, Time.deltaTime * 10f); 
    }

    private void UpdateRotation() {
        transform.rotation = Quaternion.Lerp(transform.rotation, goalPosRot.rotation, Time.deltaTime * 10f); 
    }
}
