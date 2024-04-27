using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public event Action OnDamage;
    public event Action OnDeath;

    void Start()
    {
        currentHealth = maxHealth;
        StartInteracting(this);
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if(currentHealth <= 0)
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

    private int damage = 10;
    private int delay = 10;

    public void StartInteracting(Health health)
    {
        StartCoroutine(Damage(health, delay));
    }

    IEnumerator Damage(Health health, float time)
    {
        Debug.Log("Started");
        yield return new WaitForSeconds(time);
                Debug.Log("Waited");
        health.TakeDamage(damage);
                Debug.Log("Damaged");
    }
}
