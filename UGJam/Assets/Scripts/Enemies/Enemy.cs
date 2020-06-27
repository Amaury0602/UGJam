using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IShootable
{
    MultiplyChecker multiplyChecker;
    // Start is called before the first frame update
    public bool Interactable { get; set; }

    private void Start()
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
        if (Interactable)
        {
            Wipe();
        } else
        {
            ScoreText.current.ChangeScore(false, -10);
        }
    }
    
    private void Wipe()
    {
        CinemachineShake.instance.ShakeCamera(0.5f * multiplyChecker.enemies.Count, 0.1f);
        ScoreText.current.ChangeScore(true, multiplyChecker.enemies.Count);
        multiplyChecker.enemies.Clear();
        foreach (var enemy in FindObjectsOfType<Enemy>())
        {
            Destroy(enemy.gameObject);
        }
        multiplyChecker.TestEnemies();
    }
    
}
