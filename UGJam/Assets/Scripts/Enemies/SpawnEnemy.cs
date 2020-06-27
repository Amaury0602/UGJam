using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] spawners;
    [SerializeField] private GameObject summoningEffect;



    private int enemyPrefabCount;
    private float timeToSpawn;
    private float elapsedTime;

    GameObject newSummoningEffect;


    void Start()
    {
        elapsedTime = RandomTimeBetweenSpawns();
        enemyPrefabCount = enemies.Length;
    }


    void Update()
    {
        if (Player.instance)
        {
            elapsedTime -= Time.deltaTime;
            if (elapsedTime <= 0) SpawnRandomEnemy(Random.Range(0, enemyPrefabCount));
        }
    }
    
    private void SpawnRandomEnemy(int index)
    {
        newSummoningEffect = Instantiate(summoningEffect, spawners[index].position, Quaternion.identity);
        elapsedTime = 4;
        StartCoroutine(TimeToInstantiate(index));
    }

    private IEnumerator TimeToInstantiate(int index)
    {
        yield return new WaitForSeconds(Random.Range(2, 4));
        if (newSummoningEffect != null) Destroy(newSummoningEffect);
        GameObject newEnemy = Instantiate(enemies[index], spawners[index].position, Quaternion.identity);
        elapsedTime = RandomTimeBetweenSpawns();
    }

    private int RandomTimeBetweenSpawns()
    {
        return Random.Range(3, 4);
    }
}
