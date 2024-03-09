using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.WSA;

public class Grabby : MonoBehaviour
{
    private float cooldown;
    private bool grabbing;
    private IGrabbable grabbedComponent;
    private Animator grabbedAnimator;
    private const float defaultCooldown = 1f;
    private const float grabDistance = 500f;
    private LayerMask grabbable = 1 << 3 | 1 << 7 | 1 << 9;
    public Transform grabbyPoint;
    public Animator grabbyPointAnimator;
    public LineRenderer laserLineRenderer;
    public GameObject effect;
    void Start()
    {
        cooldown = 0f;
        grabbing = false;
        grabbedComponent = null;
        grabbyPointAnimator = grabbyPoint.GetComponent<Animator>();
        effect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        laserLineRenderer.SetPosition(0, transform.position); 
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
        
        Vector3 forward = grabbyPoint.forward; 
        laserLineRenderer.SetPosition(0, transform.position); 
        laserLineRenderer.SetPosition(1, transform.position + (forward * grabDistance)); 

        RaycastHit hit;
        if (!Physics.Raycast(transform.position, forward, out hit, grabDistance, grabbable)) {return;}

        if (!hit.transform.gameObject.TryGetComponent(out grabbedComponent)) {return;}
        grabbedComponent.SubscribeToPosition(grabbyPoint);

        grabbing = true;
        if (!hit.transform.gameObject.TryGetComponent(out AsteroidBehavior _)) {return;}
        grabbedAnimator = hit.transform.gameObject.AddComponent<Animator>();
        grabbedAnimator.runtimeAnimatorController = 
            AsteroidManager.Instance.asteroidAnimator.runtimeAnimatorController; // What the fuck
        effect.SetActive(true);
        grabbedAnimator.transform.gameObject.layer = LayerMask.NameToLayer("Grabbed");
    }

    private void Ungrab() {
        grabbedComponent.Launch(transform.forward);
        grabbedComponent = null;
        grabbing = false;
        if (grabbedAnimator != null)
        {
            Destroy(grabbedAnimator);
        }
        effect.SetActive(false);
    }
}
