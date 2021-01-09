﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLazer : MonoBehaviour
{
    public PlayerMobileSystem ps;
    public GameObject explosion;
    ScoreSystemScript ss;

    private void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMobileSystem>();
        ss = GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ScoreSystemScript>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Barrier") || collision.gameObject.CompareTag("EnemyLazer"))
        {
            Instantiate(explosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            ps.canFire = false;
        }

        else if(collision.gameObject.CompareTag("IShielder"))
        {
            ss.score += 10;
            ss.pointsToGetExtraLife += 10;
            Instantiate(explosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            ps.canFire = false;
        }

        else if (collision.gameObject.CompareTag("IPrickie"))
        {
            ss.score += 15;
            ss.pointsToGetExtraLife += 15;
            Instantiate(explosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            ps.canFire = false;
        }

        else if (collision.gameObject.CompareTag("IChompy"))
        {
            ss.score += 20;
            ss.pointsToGetExtraLife += 20;
            Instantiate(explosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            ps.canFire = false;
        }

        else
        {
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
            ps.canFire = false;
        }
    }
}
