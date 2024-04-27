using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherecter : MonoBehaviour
{
    Rigidbody2D rig;
    public float x, y;
    public bool w;
    public float r, l;
    public float speed = 5f;
    public float roter = 2;
    public GameObject missile;
    public float lifetime = 3f;
    public float projectileSpeed = 5f;
    public Health health;

    void Start()
    {
        health = GetComponent<Health>();
        health.OnDeath+=()=> Destroy(this);
    }

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

    }

    private void FixedUpdate()
    {
        rig.AddForce((transform.up*y + transform.right*x)*speed, ForceMode2D.Force);
        transform.Rotate(0, 0, (r + l*-1)*roter);
    }

    void Attack()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 direction = (targetPosition - transform.position).normalized;

        GameObject projectile = Instantiate(missile, transform.position + direction*0.5f, Quaternion.identity);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = direction*projectileSpeed*10;

        StartCoroutine(DestroyMissileAfterTime(projectile, lifetime));
    }

    IEnumerator DestroyMissileAfterTime(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(obj);
    }
}