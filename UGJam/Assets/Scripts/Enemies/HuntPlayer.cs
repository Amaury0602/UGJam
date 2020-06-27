using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntPlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        rb.velocity = direction * moveSpeed * Time.deltaTime;
    }
}
