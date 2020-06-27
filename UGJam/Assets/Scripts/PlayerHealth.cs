using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    float startingHealth = 2f;
    float currentHealth;
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
