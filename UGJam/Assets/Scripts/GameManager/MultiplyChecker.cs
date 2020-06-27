using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyChecker : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    public static MultiplyChecker current;
    
    
    //list of every interactable objects
    public List<Enemy> enemies = new List<Enemy>();

    private void Awake()
    {
        current = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.L)) SpawnEnemy();

      
    }

    void SpawnEnemy() // for test purposes
    {
        Vector2 newPos = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
        Instantiate(enemy, newPos, Quaternion.identity);
    }


    public void TestEnemies()
    {
        bool isDivisibleByTwo = enemies.Count % 2 == 0 ? true : false;
        foreach (var enemy in enemies)
        {
            enemy.Interactable = isDivisibleByTwo;
        }
    }
}
