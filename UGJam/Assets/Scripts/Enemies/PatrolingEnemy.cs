using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolingEnemy : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    [SerializeField] float chasingDistance;
    [SerializeField] float moveSpeed;

    GameObject blood;
    private float maxY;
    private float minY;
    private float maxX;
    private float minX;
    private Vector2 randomSpot;
    Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
        maxY = SpawnEnemy.current.spawners[0].position.y;
        minY = SpawnEnemy.current.spawners[3].position.y;
        maxX = SpawnEnemy.current.spawners[1].position.x;
        minX = SpawnEnemy.current.spawners[0].position.x;
        waitTime = startWaitTime;
        randomSpot = NextPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if(tag == "Chasing Enemy")
        {
            if (Vector3.Distance(Player.instance.transform.position, transform.position) <= chasingDistance)
            {
                Transform player = Player.instance.transform;
                Vector2 direction = (player.position - transform.position).normalized;
                transform.position = Vector3.MoveTowards(transform.position,player.transform.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position,randomSpot, speed * Time.deltaTime);
            
                if (waitTime <= 0)
                {
                    randomSpot = NextPosition();
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,randomSpot, speed * Time.deltaTime);
        
            if (waitTime <= 0)
            {
                randomSpot = NextPosition();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        
        if (Player.instance && Player.instance.transform.position.x < transform.position.x)
        {
            transform.localScale = initialScale;
        } else
        {
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }

    }

    private Vector2 NextPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector2 newTarget = new Vector2(randomX, randomY);
        return newTarget;
    }
}
