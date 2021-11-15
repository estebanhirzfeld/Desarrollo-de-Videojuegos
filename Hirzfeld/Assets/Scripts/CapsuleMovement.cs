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

    private GameObject pointLight;
    private GameObject spotLight;

    private Vector3 enemyDirection;


    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Enemy");
        pointLight = GameObject.Find("Point Light");
        spotLight = GameObject.Find("Spot Light");

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
        pointLight.GetComponent<Light>().color = new Color(0, 255, 0); // Green
        spotLight.GetComponent<Light>().color = new Color(0, 255, 0); // Green    //Luz del Player y del Escenario
        Debug.Log("Avanza");
        enemyIsWatching = false;
    }
    
    private void Look()
    {
        enemy.transform.rotation = Quaternion.LookRotation(new Vector3(enemyDirection.x, enemyDirection.y,-180));  //El Enemigo Blanco Mira hacia el player
        enemyIsWatching = true;
        pointLight.GetComponent<Light>().color = new Color(255, 0, 0); // Red
        spotLight.GetComponent<Light>().color = new Color(255, 0, 0); // Red    //Luz del Player y del Escenario
    }


private void OnTriggerEnter(Collider other) {
    
    if (other.tag == "CheckBox" || other.name == "StartLine")            //Si el Player pisa la linea de Inicio o el CheckBox invoca Look y espera 2 segundos
    {
        Look();
        Debug.Log("Espera");
        pointLight.GetComponent<Light>().color = new Color(255, 0, 0); // Red
        spotLight.GetComponent<Light>().color = new Color(255, 0, 0); // Red    //Luz del Player y del Escenario
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

        Destroy(GameObject.Find("EndtLine"));                      //Hay que destruir los colliders de las lineas de Inico y fin para que 
        Destroy(GameObject.Find("StartLine"));                      //no llame a las luces luego de ser destruidas
        Destroy (pointLight.gameObject);
        Destroy (spotLight.gameObject);


        Debug.Log("Winner");
    }
}

}
