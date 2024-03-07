using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public HealthScript healthBar;
    public GameObject explosionPrefab;
    public GameObject explosionParticles;
    public GameObject regularCanvas;
    public GameObject deathCanvas;
    public void DealDamage(float damage) {
        if (healthBar == null) {return;}

        healthBar.Damage(damage);
        if (healthBar.health <= 0f) {Explode();}
    }

    private void Explode() {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Instantiate(explosionParticles, transform.position, Quaternion.identity);
        Destroy(regularCanvas);
        Destroy(transform.gameObject);
    }
}
