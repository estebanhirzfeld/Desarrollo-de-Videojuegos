using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBallController : MonoBehaviour

{
    public float bulletSpeed;
    public float timeToDestroyBullet;
    public Vector3 bulletDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Temporizador: " + timeToDestroyBullet);                              //Temporizador con tiempo variable desde Inspector 
        timeToDestroyBullet -= Time.deltaTime;
        if (timeToDestroyBullet < 0)
        {
            Destroy(this.gameObject);                                                   //Destruccion unicamente de la bala Instanciada
        }

        transform.Translate(bulletDirection*bulletSpeed * Time.deltaTime);           // Movimiento Recto de la bala con direccion y velocidad variables
    }
}

