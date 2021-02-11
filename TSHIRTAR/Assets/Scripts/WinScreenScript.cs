using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenScript : MonoBehaviour
{
    public NextWaveSystem nws; //NewWaveSystem Script
    public GameObject winScreenLayout; //winScreenLayout Canvas
    public GameObject startScreenLayout; //startScreenLayout Canvas

    //When the player taps on the button to play the game again, the wave counter will reset to 1, the canStartNextWave boolean will be set to false
    //The WinScreen Canvas would be inactive and the StartScreen Canvas would become active to start the game over again
    public void PlayAgainButton()
    {
        nws.waveCounter = 1;
        nws.canStartNextWave = false;
        winScreenLayout.SetActive(false);
        startScreenLayout.SetActive(true);  
    }
}
