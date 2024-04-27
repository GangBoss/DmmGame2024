using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public int damage;
    public int delay;
    public event Action OnDamage;
    public event Action OnDeath;

    void Start()
    {
        currentHealth = maxHealth;
        StartInteracting();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            if (OnDeath != null)
            {
                OnDeath();
            }
        }

        if (OnDamage != null)
        {
            OnDamage();
        }
    }

    private void StartInteracting()
    {
        StartCoroutine(Damage(delay));
    }

    IEnumerator Damage(float time)
    {
        while (currentHealth > 0)
        {
            yield return new WaitForSeconds(time);
            TakeDamage(damage);
        }
    }
}