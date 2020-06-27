using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    MultiplyChecker multiplyChecker;
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
        if (Interactable) Wipe();
        //do nothing
    }
    

    private void Wipe()
    {
        multiplyChecker.exploders.Clear();
        foreach (var enemy in FindObjectsOfType<Exploder>())
        {
            Destroy(enemy.gameObject);
        }
        multiplyChecker.TestExploders();
    }
}
