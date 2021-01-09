using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystemScript : MonoBehaviour
{
    public int score = 0;
    public int pointsToGetExtraLife;
    public TextMeshPro scoreText;
    public RespawnPlayerSystem rps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = "SCORE:" + score.ToString();
        if(pointsToGetExtraLife >= 1000)
        {
            AddLifePoint();
        }
    }

    void AddLifePoint()
    {
        rps.livesLeft += 1;
        rps.livesText.text = "LIVES:" + rps.livesLeft.ToString();
        pointsToGetExtraLife -= 1000;
    }
}
