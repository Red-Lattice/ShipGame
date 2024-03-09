using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class EnemyAI : MonoBehaviour
{
    //Parameters
    private const float SPEED = .02f;
    private const float FIRE_COOLDOWN = 0.5f;
    private const float PERSUAL_COOLDOWN = 5f;
    private const float AWARENESS_RADIUS = 200f;
    private const float PERSUAL_TIME = 10f;
    public GameObject explosionPrefab;
    public GameObject explosionParticles;
    public GameObject bulletPrefab;

    public Transform target;
    // Firing scriptable object
    public float fireCooldown = 0f;
    /// <summary>
    /// How long the enemy waits before persuing again.
    /// </summary>
    public float persualCooldown = 0f;
    private Vector3 goalPosition;
    public bool attacking;
    public Vector3 targetPos;
    /// <summary>
    /// This is how long the enemy will persue the player for.
    /// </summary>
    public float persuitTimer;

    void Start() {
        goalPosition = transform.position;
        target = EnemyManagerSingleton.target;
        persuitTimer = 0f;
    }

    void FixedUpdate() {
        if (target != null) {targetPos = target.position;}

        UpdateValues();

        if (!attacking && target != null && persualCooldown >= PERSUAL_COOLDOWN && TargetDistanceCheck())
            {StartAttacking();}
        
        SetNewDestination();

        AttemptFire();

        UpdateRotation();
        UpdatePosition();
    }
    void UpdateValues() {
        fireCooldown += (fireCooldown >= FIRE_COOLDOWN) ? 0 : Time.fixedDeltaTime; // 
        persuitTimer += (persuitTimer >= PERSUAL_TIME && attacking) ? 0 : Time.fixedDeltaTime;
        persualCooldown += (persualCooldown >= PERSUAL_COOLDOWN && !attacking) ? 0 : Time.fixedDeltaTime;
    }

    private void AttemptFire() {
        if (persuitTimer > PERSUAL_TIME) {StopFire(); return;}
        if (target == null || !attacking) {return;}
        if (!FiringAngle()) {return;}
        if (fireCooldown < FIRE_COOLDOWN) {return;}
        
        Fire();
    }
    private void Fire() {
        fireCooldown = 0f;
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    private void StopFire() {
        attacking = false;
        persualCooldown = 0f;
        persuitTimer = 0f;
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
        persuitTimer = 0f;
    }

    private bool FiringAngle() {
        return Vector3.Angle(transform.forward, target.position - transform.position) < 10f;
    }

    private bool TargetDistanceCheck() {
        return Vector3.Distance(targetPos, transform.position) 
            <= AWARENESS_RADIUS;
    }

    private void UpdatePosition() {
        transform.position += transform.forward * Speed() * 10f;
    }
    private float Speed() {
        return attacking ?
            Mathf.Clamp(
                0.005f * Mathf.Sqrt(TargetDistance(targetPos)), 
                Mathf.NegativeInfinity, 
                SPEED) :
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
        if (other.transform.gameObject.layer == 6) {return;}
        Overwatch.Instance.AsteroidDestroyed();
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Instantiate(explosionParticles, transform.position, Quaternion.identity);
        Destroy(transform.gameObject);
        Destroy(this);
    }
}
