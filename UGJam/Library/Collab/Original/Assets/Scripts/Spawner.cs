using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour {

    public Transform minSpawnX;
    public Transform maxSpawnX;
    public GameObject virus;
    public GameObject greenVirus;
    private List<GameObject> enemies = new List<GameObject>();
    [SerializeField] GameObject[] powerups;
    private int[] difficultyLevels = new int[3];
    private bool needToSpawn = true;
    private bool choiceInSpawn = false;

    private int difficultyTimer;


    private void Start()
    {
        difficultyLevels[0] = 10;
        difficultyLevels[1] = 8;
        difficultyLevels[2] = 5;
        enemies.Add(virus);
        difficultyTimer = difficultyLevels[Mathf.RoundToInt(PlayerPrefs.GetFloat("difficulty"))];
    }

    //private void Update()
    //{
    //    if (needToSpawn) StartCoroutine(SpawnSomething());
    //}

    //IEnumerator SpawnSomething()
    //{
    //    needToSpawn = false;
    //    int numSeconds = Random.Range(SetTimer(), difficultyTimer);
    //    int rand = Random.Range(0, 10);
    //    yield return new WaitForSeconds(numSeconds);
    //    if (choiceInSpawn)
    //    {
    //        if (rand <= 1)
    //        {
    //            Instantiate(powerups[Random.Range(0, 3)], RandomSpawnPos(), transform.rotation);
    //        }
    //        else
    //        {
    //            int enemyIndex = rand >= 4 ? 0 : 1;
    //            Instantiate(enemies[enemyIndex], RandomSpawnPos(), transform.rotation);
    //        }
    //    }
    //    else
    //    {
    //        Instantiate(enemies[0], RandomSpawnPos(), transform.rotation);
    //    }

    //    needToSpawn = true;

    //}

    //private Vector2 RandomSpawnPos()
    //{
    //    float randomX = Random.Range(minSpawnX.position.x, maxSpawnX.position.x);
    //    return new Vector2(randomX, transform.position.y);
    //}

    //private int SetTimer()
    //{
    //    int actualScore = Score.currentScore;
    //    if (actualScore < 20)
    //    {
    //        return 5;
    //    }
    //    else if (actualScore < 50)
    //    {
    //        return 4;
    //    } else if (actualScore < 100)
    //    {
    //        choiceInSpawn = true;
    //        enemies.Add(greenVirus);
    //        return 3;
    //    } else if (actualScore > 100 && actualScore <= 200)
    //    {
    //        return 2;
    //    } else if (actualScore > 200 && actualScore <= 400)
    //    {
    //        return 1;
    //    }
    //    else if (actualScore > 400)
    //    {
    //        return 0;
    //    }
    //    else
    //    {
    //        return 0;
    //    }
    //}
}