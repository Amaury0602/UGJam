using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour, IShootable
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] int numberOfShots = 3;
    [SerializeField] float projectileSpeed = 50f;
    [SerializeField] float offset = 90f;
    MultiplyChecker multiplyChecker;
    Quaternion projectileRotation;
    // Start is called before the first frame update
    public bool Interactable { get; set; }

    private void Start()
    {
        multiplyChecker = MultiplyChecker.current;
        multiplyChecker.exploders.Add(this);
        multiplyChecker.TestExploders();
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
        CinemachineShake.instance.ShakeCamera(0.5f * multiplyChecker.exploders.Count, 0.1f);
        ScoreText.current.ChangeScore(true, multiplyChecker.exploders.Count);
        multiplyChecker.exploders.Clear();
        foreach (var enemy in FindObjectsOfType<Exploder>())
        {
            enemy.Shoot();
            Destroy(enemy.gameObject);
        }
        multiplyChecker.TestExploders();
    }



    private void Shoot()
    {
        for (int i = 0; i < numberOfShots; i++)
        {
            projectileRotation = Quaternion.Euler(0,0,(i * 360/ numberOfShots)); 
            GameObject projectile = Instantiate(projectilePrefab,transform.position,projectileRotation);
            projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.up * projectileSpeed * Time.deltaTime; 
        }
    }
}


