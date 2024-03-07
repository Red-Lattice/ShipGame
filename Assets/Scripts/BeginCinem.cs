using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BeginCinem : MonoBehaviour
{
    [SerializeField] private ShipMovementScript shipMovement;
    public float timer;

    void Start() {
        timer = 0f;
    }
    void FixedUpdate() {
        timer += Time.fixedDeltaTime;
        if (timer > 2f) {shipMovement.canMove = true;}
        if (timer > 4f) { Destroy(transform.gameObject);}
    }
}
