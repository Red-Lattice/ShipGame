using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other) {
        Damageable damageable;
        if (other.transform.gameObject.TryGetComponent(out damageable)) {
            damageable.DealDamage(999f);
        }
    }
}
