using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverLayout;
    public GameObject startScreenLayout;
    public bool isGameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver == true)
        {
            gameOverLayout.SetActive(true);
        }
    }

    public void PressRestartButton()
    {
        isGameOver = false;
        startScreenLayout.SetActive(true);
        gameOverLayout.SetActive(false);
    }
}
