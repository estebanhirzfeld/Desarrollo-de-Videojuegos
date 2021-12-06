using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StarLevel1()
    {
    Debug.Log("Nivel 1");
    SceneManager.LoadScene("Nivel 1");
    }

    public void StarLevel2()
    {
    Debug.Log("Nivel 2");
    SceneManager.LoadScene("Nivel 2");
    }
}
