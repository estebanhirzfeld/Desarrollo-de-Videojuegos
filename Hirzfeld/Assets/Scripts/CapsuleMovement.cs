using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CapsuleMovement : MonoBehaviour
{
    public float playerSpeed;
    float cameraAxis;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        LookDirection();
        DirectionInputs();
    }

    private void DirectionInputs(){                                 //Movimiento de Poscicion del Player
        
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");                 

        transform.Translate(playerSpeed * Time.deltaTime * new Vector3(horizontalAxis, 0 , verticalAxis));
    }

    private void LookDirection(){                                   //Movimiento de camara del Player
        cameraAxis += Input.GetAxis("Mouse X");
        Quaternion angle = Quaternion.Euler(0,cameraAxis,0);
        transform.localRotation = angle;    
    }
}
