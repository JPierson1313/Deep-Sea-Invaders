using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLazer : MonoBehaviour
{
    public Animator anim;
    public float animSpeed = .2f;
    public GameObject explosion;

    private void Start()
    {
        anim.speed = animSpeed;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Barrier"))
        {
            Instantiate(explosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            
        }

        else
        {
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
