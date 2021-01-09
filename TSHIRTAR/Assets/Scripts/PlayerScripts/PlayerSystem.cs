using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    [Header("Player Components")]
    public Rigidbody rb;
    public Transform barrelEnd;
    public GameObject projectile;
    public Animator anim;

    [Header("Variables")]
    public float moveSpeed = 10;
    public float fireSpeed = 100;
    float animSpeed = .2f;
    public bool canFire;

    //RespawnPlayerSystem rps;

    // Start is called before the first frame update
    void Start()
    {
        //rps = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnPlayerSystem>();
        rb = gameObject.GetComponent<Rigidbody>();
        anim.speed = animSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3();

        moveDirection.x = Input.GetAxis("Horizontal");
        rb.velocity = moveDirection * moveSpeed;

        if (moveDirection.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        else if (moveDirection.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !canFire)
        {
            GameObject lazer = Instantiate(projectile, barrelEnd.position, barrelEnd.rotation);
            lazer.transform.SetParent(GameObject.FindGameObjectWithTag("MainGame").transform);
            lazer.GetComponent<Rigidbody>().AddForce(Vector3.down * fireSpeed);
            canFire = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("EnemyLazer"))
        {
            //rps.isDead = true;
            //rps.livesLeft -= 1;
            Destroy(gameObject);
        }
    }
}
