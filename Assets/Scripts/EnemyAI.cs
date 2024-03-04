using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class EnemyAI : MonoBehaviour
{
    //Parameters
    private const float speed = .02f;
    private const float fireCooldown = 0.5f;
    private const float targetAttackCooldown = 5f;
    private const float awarenessRadius = 200f;

    private Vector3 movement = Vector3.zero; // Encodes velocity
    public Transform target;
    // Firing scriptable object
    private float currentCooldown = 0f;
    private float currentTAC = 0f; // Target attack cooldown
    private Vector3 goalPosition;
    private bool attacking;

    void Start() {
        goalPosition = transform.position;
    }

    void FixedUpdate() {
        if (!attacking && target != null && currentTAC <= 0f && TargetDistanceCheck()) {StartAttacking();}
        SetNewDestination();
        UpdateRotation();
        UpdatePosition();
    }

    /// <summary>
    /// Returns a random, *normalized* vector.
    /// </summary>
    private Vector3 RandomVector() {
        return new Vector3(
                UnityEngine.Random.Range(-1f,1f), 
                UnityEngine.Random.Range(-1f,1f), 
                UnityEngine.Random.Range(-1f,1f))
            .normalized;
    }
    private void SetNewDestination() {
        if (Vector3.Distance(goalPosition, transform.position) < 10f) {
            goalPosition = RandomVector() * UnityEngine.Random.Range(50f,100f);
        }
    }

    void StartAttacking() {
        attacking = true;
    }

    private bool TargetDistanceCheck() {
        return Vector3.Distance(target.position, transform.position) 
            <= awarenessRadius;
    }

    private void UpdatePosition() {
        transform.position += transform.forward * Speed() * 10f;
            //attacking ?
            //Vector3.Lerp(transform.position, target.position, Speed()) :
            //Vector3.Lerp(transform.position, goalPosition, Speed()); 
            //transform.forward * speed * Time.fixedDeltaTime;
    }
    private float Speed() {
        return attacking ?
            Mathf.Clamp(0.0005f * Mathf.Sqrt(TargetDistance(target.position)), Mathf.NegativeInfinity, speed) :
            Mathf.Clamp(0.01f, Mathf.NegativeInfinity, speed);
    }

    // Good
    private void UpdateRotation() {
        transform.rotation = attacking ? Quaternion.Lerp(transform.rotation, 
            Quaternion.LookRotation(target.position - transform.position, Vector3.up),
            0.01f) :
            Quaternion.Lerp(transform.rotation, 
            Quaternion.LookRotation(goalPosition - transform.position, Vector3.up),
            0.01f); 
    }

    private float TargetDistance(Vector3 pos) {
        return Vector3.Distance(transform.position, pos);
    }
}
