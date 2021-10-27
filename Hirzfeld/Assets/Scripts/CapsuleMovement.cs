using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CapsuleMovement : MonoBehaviour
{
    public float playerSpeed;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        DirectionInputs();
    }

    void DirectionInputs(){
        
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");                 

        transform.Translate(playerSpeed * Time.deltaTime * new Vector3(horizontalAxis, 0 , verticalAxis)); 
    }
}
