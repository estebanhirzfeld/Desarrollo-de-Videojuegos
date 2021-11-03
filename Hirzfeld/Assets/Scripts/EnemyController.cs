using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject capsule;
    
    [SerializeField] private float enemySpeed;

    enum Mode {Watcher = 1, Follower, Both }
    [SerializeField] private Mode enemyMode;

    enum Range {MidRange = 1, FullRange}
    [SerializeField] private Range enemyRange;

    private float range = 4f;

    // Start is called before the first frame update
    void Start()
    {
        capsule = GameObject.Find("Capsule");       //Busca al player con el nombre de el game object "Capsule"

    }

    // Update is called once per frame
    void Update()
    {
    switch(enemyMode)
        {
            case Mode.Watcher:
            Debug.Log("Watcher");
            LookAtPlayer();
                break;
            case Mode.Follower:
            Debug.Log("Follower");
            ChasePlayer();
                break;
            case Mode.Both:
            Debug.Log("Both");
            LookAtPlayer();
            ChasePlayer();
                break;
        }

    
    }
    
    private void LookAtPlayer()                                                        //Funcion para Solo Mirar al PLayer
    {
        Vector3 direction = capsule.transform.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(direction);
        transform.rotation = newRotation;
    }

    private void ChasePlayer(){                                                    // El enemigo seguira al player en un rango definido desde Inspector
    
    if (enemyRange == Range.FullRange)
    {
        Vector3 direction = (capsule.transform.position - transform.position).normalized;
        transform.position += enemySpeed * direction * Time.deltaTime;           // Movimiento Con Seguimiento del Player con velocidad variable
    } 
    else
    {
                if (Vector3.Distance(transform.position, capsule.transform.position) >= range)
            {
                Vector3 direction = (capsule.transform.position - transform.position).normalized;
                transform.position += enemySpeed * direction * Time.deltaTime;           // Movimiento Con Seguimiento del Player con velocidad variable
            }
    }

    }
}
