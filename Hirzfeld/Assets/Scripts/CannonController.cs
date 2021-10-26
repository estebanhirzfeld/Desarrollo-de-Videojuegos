using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireFrequency = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBullet" ,1f, fireFrequency);   //Repeticion de Disparo con frecuencia variable desd Inspector
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBullet()                                          //Funcion para instanciar el prefab de la bala
    {
        Instantiate(bulletPrefab, transform);
    }
}

