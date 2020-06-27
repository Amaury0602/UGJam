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
                //if(Input.GetKey(KeyCode.DownArrow))
                //{
                //    GetComponent<Animator>().SetTrigger("Down");
                //}
                //else if(Input.GetKey(KeyCode.UpArrow))
                //{
                //    GetComponent<Animator>().SetTrigger("Up");
                //}
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                ShootHorizontalInput();
                //if(Input.GetKey(KeyCode.RightArrow))
                //{
                //    GetComponent<Animator>().SetTrigger("Right");
                //}
                //else if(Input.GetKey(KeyCode.LeftArrow))
                //{
                //    GetComponent<Animator>().SetTrigger("Left");
                //}
            }
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void ShootVerticalInput()
    {
        canShoot = false;
        CinemachineShake.instance.ShakeCamera(0.3f, 0.1f);
        GameObject topBullet = Instantiate(bullet, topGun.position, transform.rotation * Quaternion.Euler(0f, 0f, 90f));
        topBullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * bulletSpeed * Time.deltaTime;
        GameObject bottomBullet = Instantiate(bullet, bottomGun.position, transform.rotation * Quaternion.Euler(0f, 0f, -90f));
        bottomBullet.GetComponent<Rigidbody2D>().velocity = Vector2.down * bulletSpeed * Time.deltaTime;
        StartCoroutine(WaitFireRate());
    }

    private void ShootHorizontalInput()
    {
        canShoot = false;
        CinemachineShake.instance.ShakeCamera(0.5f, 0.1f);
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

