using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public bool alive = true;

    [SerializeField]float startingHealth = 2f;
    public float health = 2f;
    public float numberOfHearts;
    [SerializeField]Sprite fullHeart;
    [SerializeField]Sprite emptyHeart;
    [SerializeField] ParticleSystem blood;

    [SerializeField] Image[] hearts;
    

    void Start()
    {
        health = startingHealth;
    }

    void Update()
    {
        if(health <= 0)
        {
            Death();
        }
        if(health > numberOfHearts)
        {
            numberOfHearts = health;
        }
        
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    // Update is called once per frame
    
    public void Damage()
    {
        blood.Play();
        health -= 1;
    }

    public void Death()
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CircleCollider2D>().CompareTag("Enemy"))
        {
            Damage();
        }
    }
}
