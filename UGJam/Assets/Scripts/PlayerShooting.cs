using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform topGun;
    [SerializeField] Transform bottomGun;
    [SerializeField] Transform leftGun;
    [SerializeField] Transform rightGun;
    static public float timeBetweenShots = 0.5f;
    private bool canShoot;

    [SerializeField] private float bulletSpeed;


    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
            {
                ShootVerticalInput();
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                ShootHorizontalInput();
            }
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void ShootVerticalInput()
    {
        canShoot = false;
        GameObject topBullet = Instantiate(bullet, topGun.position, transform.rotation * Quaternion.Euler(0f, 0f, 90f));
        topBullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * bulletSpeed * Time.deltaTime;
        GameObject bottomBullet = Instantiate(bullet, bottomGun.position, transform.rotation * Quaternion.Euler(0f, 0f, -90f));
        bottomBullet.GetComponent<Rigidbody2D>().velocity = Vector2.down * bulletSpeed * Time.deltaTime;
        StartCoroutine(WaitFireRate());
    }

    private void ShootHorizontalInput()
    {
        canShoot = false;
        GameObject leftBullet = Instantiate(bullet, leftGun.position, Quaternion.identity);
        leftBullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * bulletSpeed * Time.deltaTime;
        GameObject rightBullet = Instantiate(bullet, rightGun.position, Quaternion.identity);
        rightBullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * bulletSpeed * Time.deltaTime;
        StartCoroutine(WaitFireRate());
    }

    private IEnumerator WaitFireRate()
    {
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

}

