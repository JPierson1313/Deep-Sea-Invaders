using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NextWaveSystem : MonoBehaviour
{
    [Header("Enemy Wave")]
    public GameObject wave;

    [Header("Player")]
    public GameObject player;
    public Transform playerSpawner;

    [Header("Barriers")]
    public GameObject barrier;
    public Transform barrierSpawner;

    [Header("Text")]
    public TextMeshPro waveText;

    [Header("Variables")]
    public int waveCounter = 1;
    public float countdownTimer = 2;
    public bool canStartNextWave = false;

    [Header("Win Screen")]
    public GameObject winLayout;

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

                //if (waveCounter == 2)
                //{
                //    GameObject secondWave = Instantiate(wave2, transform.position, transform.rotation);
                //    secondWave.transform.SetParent(GameObject.FindGameObjectWithTag("MainGame").transform);
                //    countdownTimer = 2;
                //    canStartNextWave = false;
                //}

                //if (waveCounter == 3)
                //{
                //    GameObject thirdWave = Instantiate(wave3, transform.position, transform.rotation);
                //    thirdWave.transform.SetParent(GameObject.FindGameObjectWithTag("MainGame").transform);
                //    countdownTimer = 2;
                //    canStartNextWave = false;
                //}
            }   
        }
        //else if(waveCounter > 3)
        //{
        //    winLayout.SetActive(true);
        //    Destroy(GameObject.FindGameObjectWithTag("Player"));
        //    Destroy(GameObject.FindGameObjectWithTag("Barrier"));
        //}
    }
}
