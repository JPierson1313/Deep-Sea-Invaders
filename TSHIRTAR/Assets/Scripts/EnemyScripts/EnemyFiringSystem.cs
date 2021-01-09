using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiringSystem : MonoBehaviour
{
    [Header("Invader List")]
    public List<GameObject> invaders;

    [Header("Projectile")]
    public GameObject projectile;

    [Header("Variables")]
    public float minTime = 0;
    public float maxTime = 4;
    public float fireSpeed = 300;
    public float countdownTimer;
    RespawnPlayerSystem rps;

    // Start is called before the first frame update
    void Start()
    {
        countdownTimer = Random.Range(minTime, maxTime);
        rps = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnPlayerSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rps.isDead != true)
        {
            countdownTimer -= Time.deltaTime;
            if (countdownTimer < 0)
            {
                int index = Random.Range(0, invaders.Count);

                GameObject invader = invaders[index];

                GameObject lazer = Instantiate(projectile, invader.transform.position, invader.transform.rotation);
                lazer.transform.SetParent(GameObject.FindGameObjectWithTag("MainGame").transform);
                lazer.GetComponent<Rigidbody>().AddForce(Vector3.up * fireSpeed);

                countdownTimer = Random.Range(minTime, maxTime);
            }
        } 
    }
}
