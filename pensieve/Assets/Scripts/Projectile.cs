using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 25;
    private Vector3? direction;
    private float lifetime = 3f;
    private float projectileSpeed = 50f;
    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyAfter(lifetime));
    }

    public void MoveTo(Vector3 targetDirection)
    {
        direction = targetDirection;
    }

    private void FixedUpdate()
    {
        if (direction is not null)
        {
            Vector2 force = new Vector2(direction.Value.x*projectileSpeed,direction.Value.y*projectileSpeed);
            rig.AddForce(force, ForceMode2D.Force);
            direction = null;
        }
    }

    private IEnumerator DestroyAfter(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Health health = other.GetComponent<Health>();

            health.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}