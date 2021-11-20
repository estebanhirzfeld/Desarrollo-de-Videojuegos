using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class CapsuleMovement : MonoBehaviour
{
    public float playerSpeed;
    float cameraAxis;

    private float horizontalAxis;
    private float verticalAxis;
    private float rotationSpeed;
    private bool enemyIsWatching;
    private GameObject goldenWall;
    private GameObject enemy;

    private Vector3 enemyDirection;
    private Vector3 goldenWallRotation;

    public bool isSmaller = false;

    private float timerGoldenWall = 2.0f;
    private bool isPlayerInGoldenWall = false;
    // Start is called before the first frame update
    void Start()
    {
        goldenWall = GameObject.Find("Pared Dorada");
        enemy = GameObject.Find("Enemy");

    }

    // Update is called once per frame
    void Update()
    {
        LookDirection();
        DirectionInputs();

        if (isPlayerInGoldenWall == true)
        {
            timerGoldenWall -= Time.deltaTime;
            if (timerGoldenWall < 0)
            {
                timerGoldenWall = 0;
            }
        }
    }

    private void DirectionInputs(){                                 //Movimiento de Poscicion del Player
        
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");                 

        transform.Translate(playerSpeed * Time.deltaTime * new Vector3(horizontalAxis, 0 , verticalAxis));
    }

    private void LookDirection(){                                   //Movimiento de camara del Player
        cameraAxis += Input.GetAxis("Mouse X");
        Quaternion angle = Quaternion.Euler(0,cameraAxis,0);
        transform.localRotation = angle;    
    }

    private void TurnLook()
    {
        enemy.transform.rotation = Quaternion.LookRotation(new Vector3(enemyDirection.x, enemyDirection.y,180));    //El Enemigo Deja de Mirar hacia el player 
        // Debug.Log("Avanza");
        enemyIsWatching = false;
    }
    
    private void Look()
    {
        enemy.transform.rotation = Quaternion.LookRotation(new Vector3(enemyDirection.x, enemyDirection.y,-180));  //El Enemigo Blanco Mira hacia el player
        enemyIsWatching = true;
    }

    private void MoveGoldenWall(){
        goldenWall.transform.position = new Vector3 (Random.Range(-8.7f, 10.5f), goldenWall.transform.position.y, Random.Range(-23.0f, 22.0f));
        goldenWall.transform.rotation = Quaternion.LookRotation(new Vector3(Random.Range(0, 360),goldenWallRotation.y,Random.Range(0, 360)));    //El Enemigo Deja de Mirar hacia el player 
        
    }

    private void OnCollisionEnter(Collision other) {
    // PARED DORADA ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    if (other.gameObject.transform.name == "Pared Dorada")
    {
        isPlayerInGoldenWall = true;
        Debug.Log("Espere 2 Segundos..");
        
        
    }
    }

    void OnCollisionStay(Collision other) {
    // PARED DORADA ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    if (other.gameObject.transform.name == "Pared Dorada" && isPlayerInGoldenWall == true)
    {
        Debug.Log("Aun Falta...");
        if (timerGoldenWall <= 0)
        {
            Debug.Log("Moviendo Portal..");
            MoveGoldenWall();
            isPlayerInGoldenWall = false;
            timerGoldenWall = 2f;
            
        }
        
    }

    // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }

    void OnTriggerEnter(Collider other) 
    {
    

    // PORTAL ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    isSmaller = !isSmaller;
    if (other.name == "Portal" && isSmaller == false)
    {
        Debug.Log("Ta chiquito? " + isSmaller);
        transform.localScale = new Vector3(0.5f,0.5f,0.5f);      //Tras Pasar el portal el Player se encoje 
        isSmaller = true;
        
    }else if (other.name == "Portal" && isSmaller == true){
        Debug.Log("Ta chiquito? " + isSmaller);
        transform.localScale = new Vector3(1, 1, 1);      //Tras Pasar el portal el Player se agranda denuevo
        isSmaller = false;
    }
    
    // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }
}

