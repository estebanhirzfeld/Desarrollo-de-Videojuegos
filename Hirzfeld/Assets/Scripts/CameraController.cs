using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool isCameraActive;
    public GameObject[] camerasArray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))                            //Cambio de camara a la Top View si se presiona Espacio
        {
            camerasArray[0].SetActive(false);
            camerasArray[1].SetActive(false);
            camerasArray[2].SetActive(true);
        }
        
        if ((Input.GetMouseButtonDown(0)&&(isCameraActive == true)))  //con el mismo click se puede intercambiuar entre la camara 1 o 2
        {
            isCameraActive = false;                                     // con este flag se modifica el valor para que entre en el otro if y se convierta en un toggle
            camerasArray[0].SetActive(true);                           
            camerasArray[1].SetActive(false);
            camerasArray[2].SetActive(false);
        }

        else if ((Input.GetMouseButtonDown(0)&&(isCameraActive == false)))  //Tambien esete script esta en el Cannon para que no puedan disparar las capsulas al mismo tiempo
        {
            isCameraActive = true;
            camerasArray[0].SetActive(false);
            camerasArray[1].SetActive(true);
            camerasArray[2].SetActive(false);
        }


    }
}
