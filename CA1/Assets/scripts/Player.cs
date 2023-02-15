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
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        

    } 

    // Update is called once per frame
    void Update()
    {
        Camera.main.ScreenToWorldPoint(Input.mousePosition);
        h = Input.GetAxisRaw("Horizontal");
        direction.x = MovementSpeed * h;
        body.velocity = direction;
        v = Input.GetAxisRaw("Vertical");
        direction.y = MovementSpeed * v;
        body.velocity = direction;
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D body=bullet.GetComponent<Rigidbody2D>();
        body.velocity = direction * BulletSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Enemy>();
        Health = Health-1;
           
    }
}
