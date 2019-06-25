using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

  
    public int damage = 1;
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject FirePoint;

    void Start()
    {
        rb.velocity = transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        DieEnemy dieEnemy = collision.GetComponent<DieEnemy>();
        dieEnemy.TakeDamage(damage);
        level1.bulletDistance = 0;

        Destroy(gameObject);
    }
    private void Update()
    {

        level1.bulletDistance = Vector3.Distance(new Vector3(0.0f, 5.0f, 0.0f), this.transform.position);
        if(level1.bulletDistance >= GunMovement.distance)
        {
            Destroy(gameObject);
        }
    }


}
