using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour, IGrabbable
{
    private Vector3 rotationAxis;
    private float rotationSpeed;
    private Transform subscribedToTransform = null;
    private Vector3 moveDirection = Vector3.zero;
    void Start()
    {
        rotationAxis = new(Random.Range(-1f,1f), Random.Range(-1f,1f), Random.Range(-1f,1f));
        rotationSpeed = Random.Range(3f, 5f);
    }

    void FixedUpdate() {
        Rotate();
        if (subscribedToTransform != null) {
            transform.position = Vector3.Lerp(transform.position, subscribedToTransform.position, 0.1f);
        }
        transform.position += moveDirection * Time.deltaTime;
    }

    /// <summary>
    /// We are gonna pick a random axis and have it rotate around that forever.
    /// </summary>
    private void Rotate() {
        transform.RotateAround(transform.position, rotationAxis, Time.fixedDeltaTime * rotationSpeed);
    }

    public void SubscribeToPosition(Transform posSetTo) {
        subscribedToTransform = posSetTo;
        moveDirection = Vector3.zero;
    }

    public void Launch(Vector3 direction)
    {
        moveDirection = direction * -50f;
        subscribedToTransform = null;
    }
}
