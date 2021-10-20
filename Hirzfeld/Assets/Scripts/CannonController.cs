using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnBullet", 1f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBullet()
    {
        Instantiate(bulletPrefab, transform);

    }
}


