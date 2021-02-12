using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NextWaveSystem : MonoBehaviour
{
    [Header("Enemy Wave")]
    public GameObject wave;  //Enemy wave used to create the waves

    [Header("Player")]
    public GameObject player; //Player game object
    public Transform playerSpawner; //Spawner for the player to respawn to when they die

    [Header("Barriers")]
    public GameObject barrier; //Barriers to protect the player from enemy fire
    public Transform barrierSpawner; //Spawner for the barriers

    [Header("Text")]
    public TextMeshPro waveText; //Text to show you the wave number you are on

    [Header("Variables")]
    public int waveCounter = 1; //Counter for the waves
    public float countdownTimer = 2; //Countdown timer for when to start the next wave
    public bool canStartNextWave = false; //Boolean to check if we can start the next wave or not

    // Update is called once per frame
    void Update()
    {
        if (canStartNextWave)
        {
            GameObject sub = GameObject.FindGameObjectWithTag("Player");
            GameObject coral = GameObject.FindGameObjectWithTag("Barrier");
            Destroy(sub);
            Destroy(coral);

            waveText.text = "WAVE " + waveCounter.ToString();

            countdownTimer -= Time.deltaTime;
            if (countdownTimer < 0)
            {
                GameObject playerSub = Instantiate(player, playerSpawner.position, playerSpawner.rotation);
                GameObject barrierGroup = Instantiate(barrier, barrierSpawner.position, barrierSpawner.rotation);
                playerSub.transform.SetParent(GameObject.FindGameObjectWithTag("MainGame").transform);
                barrierGroup.transform.SetParent(GameObject.FindGameObjectWithTag("MainGame").transform);
                waveText.text = "";

                if (waveCounter > 0)
                {
                    GameObject enemyWave = Instantiate(wave, transform.position, transform.rotation);
                    enemyWave.transform.SetParent(GameObject.FindGameObjectWithTag("MainGame").transform);
                    countdownTimer = 2;
                    canStartNextWave = false;
                }
            }   
        }
    }
}
