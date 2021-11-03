using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireFrequency = 10f;

    enum Difficulties {Easy = 1, Normal, Hard};
    [SerializeField] private Difficulties difficulty;


    // Start is called before the first frame update
    void Start()
    {
    Debug.Log(difficulty);

        switch (difficulty)
        {
            case Difficulties.Easy:
                Debug.Log("MODO FACIL");
                InvokeRepeating("SpawnBullet" ,4f, fireFrequency + 1f);   //Repeticion de Disparo con frecuencia variable desd Inspector
                break;
            case Difficulties.Normal:
                Debug.Log("MODO INTERMEDIO");
                InvokeRepeating("SpawnBullet" ,2f, fireFrequency - 1f);   //Repeticion de Disparo con frecuencia variable desd Inspector
                break;
            case Difficulties.Hard:
                Debug.Log("MODO DIFICIL");
                InvokeRepeating("SpawnBullet" ,1f, fireFrequency -0.9f);   //Repeticion de Disparo con frecuencia variable desd Inspector
                break;
            default:
                Debug.Log("ERROR");
                break;
        }
        
        
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

