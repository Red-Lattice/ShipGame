using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAuraBehavior : MonoBehaviour, IGrabbable
{
    private Collider ballCollider;
    private Transform subscribedToTransform = null;
    private Vector3 moveDirection = Vector3.zero;
    private Animator glowPartAnimator;
    private bool active = false;
    public Damageable toHeal;
    private const float healRate = 3f;
    public Transform cameraTransform;

    void Update() {
        transform.rotation = Quaternion.LookRotation(transform.position - cameraTransform.position);
    }

    void Awake() {
        cameraTransform = Camera.main.transform;
        ballCollider = GetComponent<SphereCollider>();
        glowPartAnimator = GetComponent<Animator>();
    }

    void FixedUpdate() {
        if (active) {
            toHeal.DealDamage(-Time.fixedDeltaTime * healRate);
        }
        if (subscribedToTransform != null) {
            transform.position = Vector3.Lerp(transform.position, subscribedToTransform.position, 0.1f);
        }
        transform.position += moveDirection * Time.deltaTime;
        if (transform.position.magnitude > 500f) {
            Destroy(transform.gameObject);
            AsteroidManager.Instance.AsteroidDestroyed();
        }
    }

    public Collider GetCollider()
    {
        return ballCollider;
    }

    public void Launch(Vector3 direction)
    {
        moveDirection = direction * -150f;
        subscribedToTransform = null;
        glowPartAnimator.Play("HealAuraDeactivate");
        active = false;
    }

    public void SubscribeToPosition(Transform posSetTo)
    {
        subscribedToTransform = posSetTo;
        glowPartAnimator.Play("HealAuraActive");
        active = true;
        toHeal = posSetTo.transform.parent.gameObject.GetComponent<Damageable>();
    }
}
