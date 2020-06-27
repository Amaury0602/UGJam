using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] float Startingspeed;
    [SerializeField] int coinWorth = 15;
    [SerializeField] float movementBuff = 3f;
    [SerializeField] float movementBuffTime;
    [SerializeField] float rapidFireBuffTime;
    [SerializeField] float rapidFireBuff = 0.4f;
    bool isItActivated;
    float speed;
    float rapidFireBuffTimer;
    float movementBuffTimer;
    Rigidbody2D rb;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = Startingspeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(movementBuffTimer <= 0)
        {
            speed = Startingspeed;
        }
        if(rapidFireBuffTimer <= 0 && isItActivated)
        {
            PlayerShooting.timeBetweenShots += rapidFireBuff;
            isItActivated = false;
        }
        movementBuffTimer -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float xMovement = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float yMovement = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        rb.velocity = new Vector2(xMovement, yMovement);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Collectible")
        {
            //activate PE and SFX
            FindObjectOfType<ScoreText>().AddScore(coinWorth);
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Movement")
        {
            speed = movementBuff + Startingspeed;
            movementBuffTimer = movementBuffTime;    
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Rapid Fire")
        {
            if(isItActivated == false)
            {
                PlayerShooting.timeBetweenShots -= rapidFireBuff;
                isItActivated = true;
            }
            rapidFireBuffTimer = rapidFireBuffTime;    
            Destroy(other.gameObject);
        }
    }
}
