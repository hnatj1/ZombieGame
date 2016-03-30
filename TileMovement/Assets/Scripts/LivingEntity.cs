﻿using UnityEngine;
using System.Collections;

public class LivingEntity : MonoBehaviour, IDamageable {

    public float startingHealth;
    protected float health;
    public bool dead;

    public event System.Action OnDeath;

    protected virtual void Start() {
        health = startingHealth;
    }

    public void TakeHit(float damage, RaycastHit hit) {
        health -= damage;
        if(health <= 0 )
        {
            Die();
        }
    }

    protected void Die() {
        dead = true;
        if (OnDeath != null)
        {
            OnDeath();
        }
        GameObject.Destroy(gameObject);
    }
}
