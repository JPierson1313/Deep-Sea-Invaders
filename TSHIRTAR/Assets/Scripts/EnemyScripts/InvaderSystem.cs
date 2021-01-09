using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderSystem : MonoBehaviour
{
    public GameObject enemyWave;

    [Header("Scripts")]
    public EnemyMovementSystem ms;
    public EnemyFiringSystem efs;
    GameOverScript gos;

    [Header("Animation")]
    public Animator anim;
    public float animSpeed = .2f;
    
    // Start is called before the first frame update

    void Start()
    {
        anim.speed = animSpeed;
        gos = GameObject.FindGameObjectWithTag("MainGame").GetComponent<GameOverScript>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            ms.moveUp = true;
        }
        
        else if(collision.gameObject.CompareTag("PlayerLazer"))
        {
            efs.invaders.Remove(gameObject);
            ms.numOfInvaders -= 1;
            if (ms.numOfInvaders <= ms.halfOfInvadersLeft && (ms.numOfInvaders != 1))
            {
                ms.newCountDownTimerMove -= .046f;
                ms.newCountDownTimerDown -= .046f;
                animSpeed += .05f;
            }
            else if (ms.numOfInvaders == 1)
            {
                ms.newCountDownTimerMove = .035f;
                ms.newCountDownTimerDown = -.23f;
            }
        }

        else if (collision.gameObject.CompareTag("Barrier"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GameOver"))
        {
            Debug.Log("Test");
            gos.isGameOver = true;
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Destroy(GameObject.FindGameObjectWithTag("Barrier"));
            Destroy(enemyWave); 
        }
    }
}
