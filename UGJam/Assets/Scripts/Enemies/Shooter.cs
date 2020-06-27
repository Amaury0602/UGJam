using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour, IShootable
{
    MultiplyChecker multiplyChecker;
    // Start is called before the first frame update
    public bool Interactable { get; set; }

    private void Start()
    {
        multiplyChecker = MultiplyChecker.current;
        multiplyChecker.shooters.Add(this);
        multiplyChecker.TestShooters();
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
        }
        else
        {
            ScoreText.current.ChangeScore(false, -10);
        }
    }

    private void Wipe()
    {
        CinemachineShake.instance.ShakeCamera(0.5f * multiplyChecker.shooters.Count, 0.1f);
        ScoreText.current.ChangeScore(true, multiplyChecker.shooters.Count);
        multiplyChecker.shooters.Clear();
        foreach (var enemy in FindObjectsOfType<Shooter>())
        {
            Destroy(enemy.gameObject);
        }
        multiplyChecker.TestShooters();
    }
}
