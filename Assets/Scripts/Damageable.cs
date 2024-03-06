using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public HealthScript healthBar;
    public void DealDamage(float damage) {
        healthBar.Damage(damage);
    }
}
