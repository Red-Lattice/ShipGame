using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    private Vector3 rotationAxis;
    private float rotationSpeed;
    void Start()
    {
        rotationAxis = new(Random.Range(-1f,1f), Random.Range(-1f,1f), Random.Range(-1f,1f));
        rotationSpeed = Random.Range(3f, 5f);
    }

    void FixedUpdate() {
        Rotate();
    }

    /// <summary>
    /// We are gonna pick a random axis and have it rotate around that forever.
    /// </summary>
    private void Rotate() {
        transform.RotateAround(transform.position, rotationAxis, Time.fixedDeltaTime * rotationSpeed);
    }
}
