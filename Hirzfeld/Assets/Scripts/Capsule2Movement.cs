using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule2Movement : MonoBehaviour
{
    public float playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InvertedDirectionInputs();
    }
    
    void InvertedDirectionInputs(){
        
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");                 
                                                                                                                    // Iba a capturar la posision de la primera capsula e invertirla 
        transform.Translate(playerSpeed * Time.deltaTime * new Vector3(horizontalAxis, 0 , verticalAxis) * -1);     // pero multiplicar el nuevo por -1 da el mismo resultado
    }
}


