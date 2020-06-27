using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] float timeBetweenPoints = 0.4f;
    public static int currentScore = 0;
    float timer;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            currentScore++;
            timer = timeBetweenPoints;
        }
        GetComponent<Text>().text = currentScore.ToString();
        timer -= Time.deltaTime;
    }
    public void AddScore(int addingAmount)
    {
        currentScore += addingAmount;
    } 
}
