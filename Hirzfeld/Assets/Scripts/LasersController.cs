using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasersController : MonoBehaviour
{
    [SerializeField] private float distanceRay = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastLaser();
    }

    private void RaycastLaser()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out hit, distanceRay))
        {
            Debug.Log("Choque");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distanceRay);

    }



}
// if (other.tag == "CheckBox" || other.name == "StartLine")            //Si el Player pisa la linea de Inicio o el CheckBox invoca Look y espera 2 segundos
//     {
//         Look();
//         // Debug.Log("Espera");
//         Invoke("TurnLook",2f);
//     }

//     if (enemyIsWatching == true && verticalAxis > 0.65)           //Si el Player se mueve muy rapido mientras el enemy esta mirando el juego termina
//     {
//         Debug.Log("Dead");
//         GameManager.score = 0;                                     //Si El Player Pierde, se Reinicia El Score y se reinicia la escena
//         Application.LoadLevel(Application.loadedLevel);
//         // UnityEditor.EditorApplication.isPlaying = false;
//         Application.Quit();
//     }

//     if (other.name == "EndLine")                                    //El Player al pisar la linea de meta Gana el Juego
//     {
//         transform.localScale = new Vector3(2,2,2);
//         Destroy (GameObject.FindWithTag("CheckBox"));
//         enemy.GetComponent<Collider>().isTrigger = false;

//         Debug.Log("Win");

//         GameManager.score += 1;                                     //Cada vez que el Player llegue a la meta, el score = + 1 y se reinicia la escena
//         Application.LoadLevel(Application.loadedLevel);
//         Debug.Log("Score: "+ GameManager.score);
//         // SceneManager.loadScene(SceneManager.loadedScene);
//     }