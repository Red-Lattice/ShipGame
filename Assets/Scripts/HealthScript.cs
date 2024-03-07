using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    private const float maxHealth = 100f;
    public float health {get; private set;}
    public Slider healthSlider;
    public Animator sliderAnimator;
    public Animator damageGradientAnimator;

    void Awake() {
        health = maxHealth;
    }
    void Update() {
        healthSlider.value = health;
    }
    public void Damage(float damage) {
        health -= damage;
        if (damage > 0f) {
            sliderAnimator.Play("HealthDamage"); 
            damageGradientAnimator.Play("DamageGradientFlash");
        }
    }
}
