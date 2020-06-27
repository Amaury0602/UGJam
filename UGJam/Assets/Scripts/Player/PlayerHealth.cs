using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool alive = true;

    float startingHealth = 2f;
    float currentHealth;

    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    
    public void Damage()
    {
        alive = false;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Chasing Enemy") || collision.collider.CompareTag("Enemy"))
        {
            Damage();
        }
    }
}
