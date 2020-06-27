using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    private int numberOfShots = 3;
    [SerializeField] private float timeBetweenShots = 5f;
    [SerializeField] float projectileSpeed = 50f;
    [SerializeField] Transform gunPoint;
    [SerializeField] float projectilesAngleDiff = 45f;
    [SerializeField] float offset = 90f;
    float rotZ;

    float shootCooldown;
    Quaternion projectileRotation;

    private void Start() 
    {
        shootCooldown = timeBetweenShots;    
    }

    // Update is called once per frame
   
    void Update()
    {
        if (!Player.instance) return;
        Vector3 difference = Player.instance.transform.position - transform.position;
        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + offset;
        if(shootCooldown <= 0)
        {
            Shoot();
            shootCooldown = timeBetweenShots;
        }
        shootCooldown -= Time.deltaTime;
    }

    private void Shoot()
    {
        for (int i = 0; i < numberOfShots ; i++)
        {
            projectileRotation = Quaternion.Euler(0,0,(i * projectilesAngleDiff + rotZ)); 
            GameObject projectile = Instantiate(projectilePrefab,gunPoint.position, projectileRotation);
            projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.up * projectileSpeed * Time.deltaTime; 
        }
    }
}
