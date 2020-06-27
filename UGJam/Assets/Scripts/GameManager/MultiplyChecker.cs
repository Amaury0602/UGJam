using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyChecker : MonoBehaviour
{
    public static MultiplyChecker current;
    
    
    //list of every interactable objects
    public List<Enemy> enemies = new List<Enemy>();
    public List<Exploder> exploders = new List<Exploder>();
    public List<Chaser> chasers = new List<Chaser>();
    public List<Shooter> shooters = new List<Shooter>();

    private void Awake()
    {
        current = this;
    }

    public void TestEnemies()
    {
        bool isDivisibleByTwo = enemies.Count % 2 == 0 ? true : false;
        foreach (var enemy in enemies)
        {
            enemy.Interactable = isDivisibleByTwo;
        }
    }

    public void TestExploders()
    {
        bool isDivisibleByTwo = exploders.Count % 2 == 0 ? true : false;
        foreach (var enemy in exploders)
        {
            enemy.Interactable = isDivisibleByTwo;
        }
    }

    public void TestChasers()
    {
        bool isDivisibleByTwo = chasers.Count % 2 == 0 ? true : false;
        foreach (var enemy in chasers)
        {
            enemy.Interactable = isDivisibleByTwo;
        }
    }

    public void TestShooters()
    {
        bool isDivisibleByTwo = shooters.Count % 2 == 0 ? true : false;
        foreach (var enemy in shooters)
        {
            enemy.Interactable = isDivisibleByTwo;
        }
    }
   
}
