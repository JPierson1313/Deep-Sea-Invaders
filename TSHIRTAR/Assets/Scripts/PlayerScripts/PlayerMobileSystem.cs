using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobileSystem : MonoBehaviour
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

    RespawnPlayerSystem rps;
    bool canMoveLeft;
    bool canMoveRight;
    // Start is called before the first frame update
    void Start()
    {
        rps = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnPlayerSystem>();
        rb = gameObject.GetComponent<Rigidbody>();
        anim.speed = animSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveDirection = Vector3.zero;
        
        if (canMoveLeft == true)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            moveDirection.x -= moveSpeed;
        }

        if (canMoveRight == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            moveDirection.x += moveSpeed;
        }
        rb.velocity = moveDirection * Time.deltaTime;
    }

    public void HoldLeftButton()
    {
        canMoveLeft = true;
    }

    public void HoldRightButton()
    {
        canMoveRight = true;
    }

    public void ReleaseLeftButton()
    {
        canMoveLeft = false;
    }

    public void ReleaseRightButton()
    {
        canMoveRight = false;
    }

    public void FireButton()
    {
        if (!canFire)
        {
            GameObject lazer = Instantiate(projectile, barrelEnd.position, barrelEnd.rotation);
            lazer.transform.SetParent(GameObject.FindGameObjectWithTag("MainGame").transform);
            lazer.GetComponent<Rigidbody>().AddForce(Vector3.down * fireSpeed);
            canFire = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyLazer"))
        {
            rps.isDead = true;
            rps.livesLeft -= 1;
            Destroy(gameObject);
        }
    }
}
