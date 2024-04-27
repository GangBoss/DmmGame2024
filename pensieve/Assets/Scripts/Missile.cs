using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 25;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Health health = other.GetComponent<Health>();

            health.TakeDamage(damage);

            Destroy(gameObject);
        }

    }
}
