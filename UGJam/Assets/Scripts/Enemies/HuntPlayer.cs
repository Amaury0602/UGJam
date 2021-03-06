﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntPlayer : MonoBehaviour
{
    [SerializeField] private float normalSpeed;
    [SerializeField] float chasingSpeed;
    [SerializeField] float chasingDistance;
    float moveSpeed;
    private Rigidbody2D rb;
    Vector3 initialScale;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = normalSpeed;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Player.instance) Hunt();
    }

    void Hunt()
    {
        Transform player = Player.instance.transform;
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position,player.transform.position, moveSpeed * Time.deltaTime);

        if (player.position.x < transform.position.x)
        {
            transform.localScale = initialScale;
        } else
        {
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }

    }


    private void Update()
    {
        if(tag == "Chasing Enemy" && Player.instance)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        if (Vector3.Distance(Player.instance.transform.position, transform.position) <= chasingDistance)
        {
            anim.SetBool("angry", true);
            moveSpeed = chasingSpeed;
        }
        else
        {
            anim.SetBool("angry", false);
            moveSpeed = normalSpeed;
        }
    }
}
