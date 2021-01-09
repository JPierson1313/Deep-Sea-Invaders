using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenScript : MonoBehaviour
{
    public NextWaveSystem nws;
    public GameObject winScreenLayout;
    public GameObject startScreenLayout;

    public void PlayAgainButton()
    {
        nws.waveCounter = 1;
        nws.canStartNextWave = false;
        winScreenLayout.SetActive(false);
        startScreenLayout.SetActive(true);  
    }
}
