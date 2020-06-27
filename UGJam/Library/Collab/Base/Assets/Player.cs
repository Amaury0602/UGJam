using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        if(Input.GetAxisRaw("Fire1") > 0)
        {
            print("fire");
        }
    }

    private void Move()
    {
        float xMovement = Input.GetAxisRaw("Horizontal") * speed;
        float yMovement = Input.GetAxisRaw("Vertical") * speed;
        rb.velocity = new Vector2(xMovement, yMovement);
    }
}
