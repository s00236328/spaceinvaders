using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
    
{

  
    bool alwaysTrack = false;
    Transform PlayerTransform;
    public float MovementSpeed = 10;
    public int Damage = 1;
    GameManager manager;
    Rigidbody2D body;
    GameObject player;
    Vector2 direction;



    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerTransform = player.transform; 
        body = GetComponent<Rigidbody2D>();
        GameObject.FindGameObjectWithTag("GameController");
        manager = gameObject.AddComponent<GameManager>();

    }
    void Update()
    {
        direction = PlayerTransform.position - transform.position;
        direction.Normalize();
        body.velocity = direction * MovementSpeed;
        transform.up = direction;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        
    }
}
