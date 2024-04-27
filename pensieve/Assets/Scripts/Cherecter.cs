using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherecter : MonoBehaviour
{
    public float speed = 5f;
    public GameObject missile;
    public float lifetime = 3f;
    public float projectileSpeed = 5f;
    public Health health;

    void Start()
    {
        health = GetComponent<Health>();
        health.OnDeath+=()=> Destroy(this);
    }

    void Attack()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        GameObject projectile = Instantiate(missile, transform.position, Quaternion.identity);

        Vector3 direction = (targetPosition - transform.position).normalized;
        
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = direction * projectileSpeed * 10;

        StartCoroutine(DestroyMissileAfterTime(projectile, lifetime));
    }

    IEnumerator DestroyMissileAfterTime(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(obj);
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed * moveX);
        transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed * moveY);
        
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
}
