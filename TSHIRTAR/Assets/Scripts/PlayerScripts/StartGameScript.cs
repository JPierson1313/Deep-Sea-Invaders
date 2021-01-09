using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{
    public NextWaveSystem nws;
    public RespawnPlayerSystem rps;
    public ScoreSystemScript sss;

    // Update is called once per frame
    //void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Space))
    //    {
    //        nws.canStartNextWave = true;
    //        nws.waveCounter = 1;
    //        rps.livesLeft = 3;
    //        rps.livesText.text = "LIVES:" + rps.livesLeft.ToString();
    //        sss.score = 0;
    //        sss.pointsToGetExtraLife = 0;
    //        this.gameObject.SetActive(false);
    //    }
    //}

    public void PressStartButton()
    {
        nws.canStartNextWave = true;
        nws.waveCounter = 1;
        rps.livesLeft = 3;
        rps.livesText.text = "LIVES:" + rps.livesLeft.ToString();
        sss.score = 0;
        sss.pointsToGetExtraLife = 0;
        this.gameObject.SetActive(false);
    }
}
