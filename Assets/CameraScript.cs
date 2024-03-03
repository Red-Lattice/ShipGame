using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private Transform lookAtTarget;

    void Start() {
        cam = GetComponent<Camera>();
    }

    void Update() {
        cam.transform.LookAt(Lerping());
    }

    private Vector3 Lerping() {
        return Vector3.Lerp(transform.rotation * transform.forward, 
            lookAtTarget.position, 
            0.2f); 
    }
}
