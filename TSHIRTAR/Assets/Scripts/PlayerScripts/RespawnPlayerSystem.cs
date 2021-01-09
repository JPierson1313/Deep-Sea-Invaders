using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RespawnPlayerSystem : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;

    [Header("Score Text")]
    public TextMeshPro livesText;

    [Header("Variables")]
    public bool isDead = false;
    public float restartTimer = .5f;
    public int livesLeft = 3;

    [Header("GameOverScript")]
    public GameOverScript gos;

    // Update is called once per frame
    void Update()
    {
        
        if (isDead == true && livesLeft > 0)
        {
            livesText.text = "LIVES:" + livesLeft.ToString();
            restartTimer -= Time.deltaTime;
            if(restartTimer < 0)
            {
                GameObject newShip = Instantiate(player, transform.position, transform.rotation);
                newShip.transform.SetParent(GameObject.FindGameObjectWithTag("MainGame").transform);
                restartTimer = 1f;
                isDead = false;
            }
        }

        if(livesLeft == 0)
        {
            livesText.text = "LIVES:" + livesLeft.ToString();
            gos.isGameOver = true;
            Destroy(GameObject.FindGameObjectWithTag("Barrier"));
            Destroy(GameObject.FindGameObjectWithTag("EnemyWave"));
            livesLeft = -1;
        }
    }
}
