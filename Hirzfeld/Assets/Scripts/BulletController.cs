using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour

{
    public float bulletSpeed;
    public float timeToDestroyBullet;
    public Vector3 bulletDirection;
    
    private GameObject capsule;


    // Start is called before the first frame update
    void Start()
    {
        capsule = GameObject.Find("Capsule");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // transform.localScale = new Vector3(transform.localScale.x * 2,transform.localScale.y * 2,transform.localScale.z * 2); //Cambio de Escala al Doble con cada Presion de Tecla
                                                                                            
            transform.localScale = new Vector3(1 ,1 ,1 ); // Cambio de Escala al doble Una Sola Vez
        }

        Debug.Log("Temporizador: " + timeToDestroyBullet);                              //Temporizador con tiempo variable desde Inspector 
        timeToDestroyBullet -= Time.deltaTime;
        if (timeToDestroyBullet < 0)
        {
            Destroy(this.gameObject);                                                   //Destruccion unicamente de la bala Instanciada
        }
        
        BulletChase();
        LookAtPlayer();
        // transform.Translate(bulletDirection*bulletSpeed * Time.deltaTime);           // Movimiento Recto de la bala con direccion y velocidad variables
    }
    void BulletChase(){
        Vector3 direction = (capsule.transform.position - transform.position).normalized;
        transform.position += bulletSpeed * direction * Time.deltaTime;           // Movimiento Con Seguimiento hacia el Player con velocidad variable
    }

    void LookAtPlayer()
    {
        Vector3 direction = capsule.transform.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(direction);
        transform.rotation = newRotation;
    }

}

