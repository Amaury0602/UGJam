using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] float bulletTimer;
    void Update()
    {
        if(bulletTimer <= 0)
        {
            Destroy(gameObject);
        }
        bulletTimer -= Time.deltaTime;    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.collider.GetComponent<Enemy>())
        {
            collision.collider.GetComponent<Enemy>().GetShot();
        }
    }
}
