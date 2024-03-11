using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementScript : MonoBehaviour
{
    [SerializeField] private CameraScript camScript;
    public Damageable damageableComp;
    public Transform parentTransform;
    public const float playerSpeed = 10f;
    private const float sprintSpeedBoost = 2.5f;
    private float sensitivity = 5f;
    Vector2 currentLook;
    public Transform grabbyPointTransform;
    public bool canMove;

    void Awake() {
        canMove = false;
        EnemyManagerSingleton.target = transform;
        damageableComp = GetComponent<Damageable>();
    }

    void Update() {
        sensitivity = GameSettings.sensitivity;
        parentTransform.position -= parentTransform.forward * Speed();
    }

    private float Speed() {
        return Time.deltaTime * playerSpeed * (Input.GetMouseButton(1) ? sprintSpeedBoost : 1f);
    }

    void FixedUpdate()
    {
        if (!canMove) {return;}

        RotateMainCamera();
        currentLook = Vector2.Lerp(currentLook, currentLook, 0.8f);
    }

    void OnTriggerEnter(Collider other) {
        damageableComp.DealDamage(Input.GetMouseButton(1) ? 999f : 25f);
    }

    private bool UpsideDown() {
        return transform.position.y < grabbyPointTransform.position.y;
    }

    void RotateMainCamera()
    {
        Vector2 mouseInput = new Vector2(
            (UpsideDown() ? -1f : 1) * Input.GetAxisRaw("Mouse X"), 
            Input.GetAxisRaw("Mouse Y"));
        mouseInput.x *= sensitivity;
        mouseInput.y *= sensitivity;

        currentLook.x += mouseInput.x;
        currentLook.y += mouseInput.y;

        parentTransform.localRotation = Quaternion.AngleAxis(-currentLook.y, Vector3.right);
        parentTransform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
        parentTransform.localRotation = Quaternion.Euler(currentLook.y, currentLook.x, 0);
    }
}
