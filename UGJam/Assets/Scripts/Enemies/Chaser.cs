using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour, IShootable
{
    MultiplyChecker multiplyChecker;
    [SerializeField]GameObject blood;
    // Start is called before the first frame update
    public bool Interactable { get; set; }

    private void Start()
    {
        multiplyChecker = MultiplyChecker.current;
        multiplyChecker.chasers.Add(this);
        multiplyChecker.TestChasers();
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
        CinemachineShake.instance.ShakeCamera(0.5f * multiplyChecker.chasers.Count, 0.1f);
        ScoreText.current.ChangeScore(true, multiplyChecker.chasers.Count);
        multiplyChecker.chasers.Clear();
        foreach (var enemy in FindObjectsOfType<Chaser>())
        {
            Instantiate(blood, enemy.transform.position,enemy.transform.rotation);
            Destroy(enemy.gameObject);
        }
        multiplyChecker.TestChasers();
    }
}
