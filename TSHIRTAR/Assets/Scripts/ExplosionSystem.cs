using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(GameObject.FindGameObjectWithTag("MainGame").transform);
        Destroy(gameObject, .2f);
    }
}
