using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MovementSpeed = 10;
    public int Health=100;
    public GameObject BulletPrefab;
    public float BulletSpeed = 10;
    float h, v;
    Rigidbody2D body;
    Vector3 mousePosition;
    Vector3 direction;
    private float fireRate = .1f;
    private float nextFire = -.1f;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.up = (mousePosition - transform.position);

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        direction.x = MovementSpeed * h;
        direction.y = MovementSpeed * v;

        body.velocity = direction;

        if (Input.GetButton("Fire1"))
        {
            if (nextFire > 0)
            {
                nextFire -= Time.deltaTime;
                return;
                
            }
            else
            {
                Shoot();  
            }

            
        }
    }

    void Shoot()
    {

        GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D body=bullet.GetComponent<Rigidbody2D>();
        body.velocity = transform.up * BulletSpeed;
        nextFire = fireRate;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           Enemy e = collision.gameObject.GetComponent<Enemy>();
            Health = Health - e.Damage; ;
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
           
    }
}
