using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCheckController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject targetLight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == target.name)
        {
            targetLight.GetComponent<Light>().color = new Color(0, 255, 0); // Green
            targetLight.GetComponent<Light>().range = 1; // Intensidad 1
        }
    }
}
