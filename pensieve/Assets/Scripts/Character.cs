using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Rigidbody2D rig;
    public float speed = 5f;
    public GameObject projectile;
    private float x, y;
    private float weaponRate;
    private Health health;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        health.OnDeath+=()=> Destroy(this);
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
    }

    void Attack()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 direction = (targetPosition - transform.position).normalized;

        GameObject obj= Instantiate(this.projectile, transform.position + direction*0.5f, Quaternion.identity);
        var projectile= obj.GetComponent<Projectile>();
        projectile.MoveTo(direction);
    }

    
}