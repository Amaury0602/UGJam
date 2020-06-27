using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerator : MonoBehaviour
{
    [SerializeField] GameObject rockPrefab;
    float numberOfRocks;
    private float maxY;
    private float minY;
    private float maxX;
    private float minX;
    private Vector2 randomSpot;

    void Start()
    {
        numberOfRocks = UnityEngine.Random.Range(1,6);
        maxY = SpawnEnemy.current.spawners[0].position.y;
        minY = SpawnEnemy.current.spawners[3].position.y;
        maxX = SpawnEnemy.current.spawners[1].position.x;
        minX = SpawnEnemy.current.spawners[0].position.x;
        for (int i = 0; i < numberOfRocks + 1; i++)
        {
            float randomX = UnityEngine.Random.Range(minX, maxX);
            float randomY = UnityEngine.Random.Range(minY, maxY);
            Vector3 rockLocation = new Vector3(randomX, randomY,0);
            Instantiate(rockPrefab,rockLocation, transform.rotation);
        }
    }

    
}
