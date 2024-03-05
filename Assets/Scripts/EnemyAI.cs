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
    public bool attacking;
    public Vector3 targetPos;

    void Start() {
        goalPosition = transform.position;
        target = EnemyManagerSingleton.target;
    }

    void FixedUpdate() {
        if (target != null) {targetPos = target.position;}
        if (!attacking && target != null && currentTAC <= 0f && TargetDistanceCheck()) {StartAttacking();}
        
        SetNewDestination();

        AttemptFire();

        UpdateRotation();
        UpdatePosition();
    }

    private void AttemptFire() {
        currentCooldown -= (currentCooldown <= 0f) ? 0 : Time.fixedDeltaTime;

        if (target == null || !attacking) {return;}
        if (!FiringAngle()) {return;}
        if (currentCooldown > 0f) {return;}
        
        Fire();
    }
    private void Fire() {

    }

    /// <summary>
    /// Returns a random, *normalized* vector.
    /// </summary>
    public static Vector3 RandomVector() {
        return new Vector3(
                UnityEngine.Random.Range(-1f,1f), 
                UnityEngine.Random.Range(-1f,1f), 
                UnityEngine.Random.Range(-1f,1f))
            .normalized;
    }
    private void SetNewDestination() {
        if (Vector3.Distance(goalPosition, transform.position) < 5f) {
            goalPosition = RandomVector() * UnityEngine.Random.Range(50f,100f);
        }
    }

    void StartAttacking() {
        attacking = true;
    }

    private bool FiringAngle() {
        return Vector3.Angle(transform.forward, transform.position - target.position) < 1f;
    }

    private bool TargetDistanceCheck() {
        return Vector3.Distance(targetPos, transform.position) 
            <= awarenessRadius;
    }

    private void UpdatePosition() {
        transform.position += transform.forward * Speed() * 10f;
    }
    private float Speed() {
        return attacking ?
            Mathf.Clamp(
                0.005f * Mathf.Sqrt(TargetDistance(targetPos)), 
                Mathf.NegativeInfinity, 
                speed) :
            0.01f;
    }

    // Good
    private void UpdateRotation() {
        transform.rotation = attacking ? Quaternion.Lerp(transform.rotation, 
            Quaternion.LookRotation(targetPos - transform.position, Vector3.up),
            0.05f) :
            Quaternion.Lerp(transform.rotation, 
            Quaternion.LookRotation(goalPosition - transform.position, Vector3.up),
            0.01f); 
    }

    private float TargetDistance(Vector3 pos) {
        return Vector3.Distance(transform.position, pos);
    }

    void OnTriggerEnter(Collider other) {
        Overwatch.AsteroidDestroyed();
        Destroy(this);
    }
}
