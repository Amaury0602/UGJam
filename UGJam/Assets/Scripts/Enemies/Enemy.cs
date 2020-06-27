using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    MultiplyChecker multiplyChecker;
    // Start is called before the first frame update
    public bool Interactable { get; set; }

    void Start()
    {
        multiplyChecker = MultiplyChecker.current;
        multiplyChecker.enemies.Add(this);
        multiplyChecker.TestEnemies();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GetShot()
    {
        if (Interactable) Destroy(gameObject);
        //do nothing
    }

    private void OnDestroy()
    {
        List<Enemy> allEnemies = multiplyChecker.enemies;
        for (int i = 0; i < allEnemies.Count; i++)
        {
            if (allEnemies[i] == this) allEnemies.RemoveAt(i);
        }
        multiplyChecker.TestEnemies();
    }
    
}
