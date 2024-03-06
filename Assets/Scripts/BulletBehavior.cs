using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public const float speed = 4f;
    private const float lifetime = 2f;
    private RaycastHit hit;
    public LayerMask hitable;
    public float age = 0f;
    void Update() {
        age += Time.deltaTime;
        if (age >= lifetime) {Destroy(transform.gameObject);}

        Vector3 forward = transform.forward * speed;
        if (!Physics.Raycast(transform.position, forward, out hit, speed, hitable)) 
            {transform.position += forward; return;}
            
        Destroy(transform.gameObject);
    }
}
