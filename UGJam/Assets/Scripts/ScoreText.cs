using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public static ScoreText current;

    public int Score { get; set; }
    private Animator anim;
    private Text UIText;

    private void Awake()
    {
        current = this;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        UIText = GetComponent<Text>();
    }
    


    public void ChangeScore(bool positivePoints, int objectsInteracted)
    {
        if (!positivePoints)
        {
            anim.SetTrigger("scoreDown");
            Score -= 3;
        } 
        if (positivePoints)
        {
            anim.SetTrigger("scoreUp");
            if (objectsInteracted <= 2)
            {
                Score += 4;
            } else if (objectsInteracted >= 4)
            {
                Score += 4 * objectsInteracted;
            } else if (objectsInteracted >= 8)
            {
                Score += 8 * objectsInteracted;
            }
            Score += objectsInteracted;
        }
        
        UIText.text = Score.ToString();
    } 
}
