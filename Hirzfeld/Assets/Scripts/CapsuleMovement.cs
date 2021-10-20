using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CapsuleMovement : MonoBehaviour
{
    public float playerScale;
    public float playerSpeed;
    public bool playerDirection;
    private float playerLife;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Inicio");
        Debug.Log("Jugador con Vida al " + playerLife + "%");

        transform.position = new Vector3(0, 2, 1);
        transform.localScale = new Vector3(1 * playerScale,1 * playerScale,1 * playerScale ); //Cambio de Escala Inicial 1 vez, modificable desde el Inspector

    }

    // Update is called once per frame
    void Update()
    {
        MovimientoLateral();                        

        if ((transform.position.x > -6.0f) || (transform.position.x < 6.0f)) // Si la Capsula Esta Dentro del Plano, recuperara toda la vida (100%)
        {
            RecuperacionDeVida();
            Debug.Log("Jugador con Vida al " + playerLife + "%");
        }

        if ((transform.position.x < -6.0f) || (transform.position.x > 6.0f))
        {
            DañoTotal();
            Debug.Log("Jugador Eliminado ");
            Debug.Log("Jugador con Vida al " + playerLife + "%");            // Si la Capsula Sale del Plano, Sera Elimnado y su vida se reducira completamente (0%)
        }
    }

    void MovimientoLateral()
    {
        float direction = Convert.ToSingle(playerDirection);                // Conversion de bool a float, true = 1, false = 0
        if (direction == 0)
        {
            direction = -1;
        }                                                                   // Como false = 0 la direccion y la velocidad, siempre se multiplicaran por 0 y la capsula no se moveria
                                                                            // por lo que si el 'playerDirection' = 0/false, la direcion ahora valdra '-1'

        transform.position += new Vector3(1 * playerSpeed * Time.deltaTime * direction, 0 , 0);  
    }


    void DañoTotal()
    {
        playerLife = 0;
    }

    float RecuperacionDeVida()
    {   
        playerLife = 100 ;
        return playerLife;
    }
}
