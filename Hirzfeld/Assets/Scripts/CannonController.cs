using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))                //Con El Click Izquierdo El cannon Dispara una bola de Tennis
        {
            Debug.Log("Disparo!");
            Instantiate(bulletPrefab, transform);
        }
    }



}

