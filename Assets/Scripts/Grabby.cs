using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;

public class Grabby : MonoBehaviour
{
    private float cooldown;
    private bool grabbing;
    private IGrabbable grabbedComponent;
    private Animator grabbedAnimator;
    private const float defaultCooldown = 1f;
    private const float grabDistance = 100f;
    private LayerMask grabbable = 1 << 3;
    public Transform grabbyPoint;
    public Animator grabbyPointAnimator;
    public LineRenderer laserLineRenderer;
    void Start()
    {
        cooldown = 0f;
        grabbing = false;
        grabbedComponent = null;
        grabbyPointAnimator = grabbyPoint.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0f) {cooldown -= Time.deltaTime * 5f;}
        if (Input.GetMouseButtonDown(0) && cooldown <= 0f) {
            if (grabbing) {
                Ungrab();
                return;
            }
            Grab();
        }
    }

    private void Grab() {
        cooldown = defaultCooldown;
        grabbyPointAnimator.Play("LaserFlash");
        
        RaycastHit hit;

        Vector3 forward = -1 * grabbyPoint.forward; // Grabby point is backwards lol
        laserLineRenderer.SetPosition(0, transform.position); 
        laserLineRenderer.SetPosition(1, transform.position + (forward * grabDistance)); 

        if (Physics.Raycast(transform.position, forward, out hit, grabDistance, grabbable))
        {
            IGrabbable grabbableComponent;
            if (hit.transform.gameObject.TryGetComponent(out grabbableComponent))
            {
                grabbedComponent = grabbableComponent;
                grabbableComponent.SubscribeToPosition(grabbyPoint);
                grabbing = true;
                grabbedAnimator = hit.transform.gameObject.AddComponent<Animator>();
                grabbedAnimator.runtimeAnimatorController = AsteroidManager.Instance.asteroidAnimator.runtimeAnimatorController;
            }
        }
    }

    private void Ungrab() {
        grabbedComponent.Launch(transform.forward);
        grabbedComponent = null;
        grabbing = false;
        if (grabbedAnimator != null)
        {
            Destroy(grabbedAnimator);
        }
    }
}
