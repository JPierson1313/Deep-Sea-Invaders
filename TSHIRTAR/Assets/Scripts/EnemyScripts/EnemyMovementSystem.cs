using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementSystem : MonoBehaviour
{
    [Header("Bools")]
    public bool isFlipped;
    public bool moveUp = false;

    [Header("Movement Speed")]
    public float moveSpeed = .2f;

    [Header("Invader Numbers")]
    public int numOfInvaders = 35;
    public int halfOfInvadersLeft = 16;

    [Header("Countdown Timers")]
    public float newCountDownTimerMove = .75f;
    public float newCountDownTimerDown = .5f;

    public float countdownTimerMovement = .75f;
    public float countdownTimerDown = .5f;

    RespawnPlayerSystem rps;
    NextWaveSystem nws;
    void Start()
    {
        rps = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnPlayerSystem>();
        nws = GameObject.FindGameObjectWithTag("WaveSpawner").GetComponent<NextWaveSystem>();
    }

    void Update()
    {
        if(numOfInvaders == 0)
        {
            nws.canStartNextWave = true;
            nws.waveCounter += 1;
            Destroy(gameObject);
        }
    }
    
    void FixedUpdate()
    {
        if(rps.isDead != true)
        {
            if (moveUp == false)
            {
                countdownTimerMovement -= Time.deltaTime;
                if (countdownTimerMovement < 0)
                {
                    if (isFlipped == false)
                    {
                        transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y, transform.position.z);
                    }

                    else
                    {
                        transform.position = new Vector3(transform.position.x - moveSpeed, transform.position.y, transform.position.z);
                    }
                    countdownTimerMovement = newCountDownTimerMove;
                }
            }

            else if (moveUp == true)
            {
                countdownTimerDown -= Time.deltaTime;
                if (countdownTimerDown < 0)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z);
                    isFlipped = !isFlipped;
                    countdownTimerDown = newCountDownTimerDown;
                    moveUp = false;
                }
            }
        }
    }
}
