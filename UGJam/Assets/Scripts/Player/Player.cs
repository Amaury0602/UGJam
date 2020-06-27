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
    [SerializeField] GameObject coinPE;
    [SerializeField] GameObject powerupPE;
    [SerializeField] ParticleSystem dust;
    bool isItActivated;
    float speed;
    float rapidFireBuffTimer;
    float movementBuffTimer;
    Rigidbody2D rb;
    Animator anim;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
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

        ControlAnimations();
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
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            dust.Play();
        }
        
    }

    private void ControlAnimations()
    {
        anim.SetFloat("directionX", rb.velocity.x);
        anim.SetFloat("directionY", rb.velocity.y);

        if (rb.velocity.y == 0 && rb.velocity.x == 0) anim.SetTrigger("idle");
        //if (rb.velocity.x < 0)
        //{
        //    anim.SetBool("goLeft", true);
        //} else
        //{
        //    anim.SetBool("goLeft", false);
        //}

        //if (rb.velocity.x > 0)
        //{
        //    anim.SetBool("goRight", true);
        //} else
        //{
        //    anim.SetBool("goRight", false);
        //}

        //if (rb.velocity.y < 0)
        //{
        //    anim.SetBool("goDown", true);
        //} else
        //{
        //    anim.SetBool("goDown", false);
        //}

        //if (rb.velocity.y > 0)
        //{
        //    anim.SetBool("goUp", true);
        //} else
        //{
        //    anim.SetBool("goUp", false);
        //}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Collectible")
        {
            //activate PE and SFX
            Instantiate(coinPE,other.gameObject.transform.position,gameObject.transform.rotation);
            ScoreText.current.ChangeScore(true, coinWorth);
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Movement")
        {
            Instantiate(powerupPE,other.gameObject.transform.position,gameObject.transform.rotation);
            speed = movementBuff + Startingspeed;
            movementBuffTimer = movementBuffTime;    
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Rapid Fire")
        {
            Instantiate(powerupPE,other.gameObject.transform.position,gameObject.transform.rotation);
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
