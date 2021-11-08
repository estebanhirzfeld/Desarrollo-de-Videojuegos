using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject capsule;
    
    [SerializeField] private float enemySpeed;
    private Rigidbody rbEnemy;

    enum Mode {Watcher = 1, Follower, Both }
    [SerializeField] private Mode enemyMode;

    enum Range {MidRange = 1, FullRange}
    [SerializeField] private Range enemyRange;

    private float range = 4f;
    private Vector3 capsuleDirection;
    // Start is called before the first frame update
    void Start()
    {
        capsule = GameObject.Find("Capsule");       //Busca al player con el nombre de el game object "Capsule"
        rbEnemy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void FixedUpdate() {
            capsuleDirection = GetCapsuleDirection();

    switch(enemyMode)
        {
            case Mode.Watcher:
            LookAtPlayer();
                break;
            case Mode.Follower:
            ChasePlayer();
                break;
            case Mode.Both:
            LookAtPlayer();
            ChasePlayer();

                break;
        }

    }

    private void LookAtPlayer()                                                        //Funcion para Solo Mirar al PLayer
    {
        rbEnemy.rotation = Quaternion.LookRotation(new Vector3(capsuleDirection.x, 0 ,capsuleDirection.z));
        // Vector3 direction = capsule.transform.position - transform.position;
        // Quaternion newRotation = Quaternion.LookRotation(direction);
        // transform.rotation = newRotation;
    }

    private void ChasePlayer(){                                                    // El enemigo seguira al player en un rango definido desde Inspector
    
    if (enemyRange == Range.FullRange)
    {
            capsuleDirection = GetCapsuleDirection();
            rbEnemy.AddForce(capsuleDirection);               // Reemplaza a ChasePlayer  // Movimiento Con Seguimiento del Player con velocidad variable
    } 
    else
    {
                if (Vector3.Distance(transform.position, capsule.transform.position) >= range)
            {
            capsuleDirection = GetCapsuleDirection();
            rbEnemy.AddForce(capsuleDirection);                 // Movimiento Con Seguimiento del Player con velocidad variable
            }
    }

    }

    private Vector3 GetCapsuleDirection(){
        return capsule.transform.position - transform.position;
    }
}
