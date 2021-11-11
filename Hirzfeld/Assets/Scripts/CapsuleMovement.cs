using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CapsuleMovement : MonoBehaviour
{
    public float playerSpeed;
    float cameraAxis;

    private float horizontalAxis;
    private float verticalAxis;
    private float rotationSpeed;
    private bool enemyIsWatching;
    private GameObject enemy;
    private Vector3 enemyDirection;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Enemy");

    }

    // Update is called once per frame
    void Update()
    {
        LookDirection();
        DirectionInputs();
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
        Debug.Log("Avanza");
        enemyIsWatching = false;
    }
    
    private void Look()
    {
        enemy.transform.rotation = Quaternion.LookRotation(new Vector3(enemyDirection.x, enemyDirection.y,-180));  //El Enemigo Blanco Mira hacia el player
        enemyIsWatching = true;
    }


private void OnTriggerEnter(Collider other) {
    
    if (other.tag == "CheckBox" || other.name == "StartLine")            //Si el Player pisa la linea de Inicio o el CheckBox invoca Look y espera 2 segundos
    {
        Look();
        GetComponent<Light>().color = 
        Debug.Log("Espera");
        Invoke("TurnLook",2f);
    }

    if (enemyIsWatching == true && verticalAxis > 0.65)           //Si el Player se mueve muy rapido mientras el enemy esta mirando el juego termina
    {
        Debug.Log(verticalAxis);
        Debug.Log("Dead");
        // UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    if (other.name == "EndLine")                                    //El Player al pisar la linea de meta Gana el Juego
    {
        transform.localScale = new Vector3(2,2,2);
        Destroy (GameObject.FindWithTag("CheckBox"));
        enemy.GetComponent<Collider>().isTrigger = false;



        Debug.Log("Winner");
    }
}

}
