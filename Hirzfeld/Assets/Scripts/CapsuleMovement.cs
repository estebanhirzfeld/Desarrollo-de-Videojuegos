using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class CapsuleMovement : MonoBehaviour
{
    public float playerSpeed;
    float cameraAxis;

    private float horizontalAxis;
    private float verticalAxis;
    private float rotationSpeed;
    private bool enemyIsWatching;
    private GameObject goldenWall;
    private GameObject enemy;

    private Vector3 enemyDirection;
    private Vector3 goldenWallRotation;

    public bool isSmaller = false;

    private float timerGoldenWall = 2.0f;
    private bool isPlayerInGoldenWall = false;


    [SerializeField] private int indexItem = 0;

    private InventoryManager mginventory;


    // Start is called before the first frame update
    void Start()
    {
        mginventory = GetComponent<InventoryManager>();

    }

    // Update is called once per frame
    void Update()
    {
        LookDirection();
        DirectionInputs();

        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnItem();
        }


        // if (Input.GetKeyDown(KeyCode.Tab))
        // {
        //     indexItem++;
        //     if (indexItem == boxes.Length)
        //     {
        //         indexItem = 0;
        //     }
        //     SwitchItems(indexItem);
        // }
        // if (Input.GetKeyDown(KeyCode.Tab))
        // {
        //     indexItem++;
        //     if (indexItem == boxes.Length)
        //     {
        //         indexItem = 0;
        //     }
        //     SwitchItems(indexItem);
        // }

        // void SwitchItems(int index)
        // {
        //     Debug.Log("Item Selected: " + boxes[index].name);
        // }


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


    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("ColorBox"))
        {
            GameObject boxItem = other.gameObject;
            mginventory.AddItem(boxItem);
            boxItem.SetActive(false);
            Debug.Log(boxItem.name);
        }
    }

        private void SpawnItem()
    {
        GameObject boxItem = mginventory.GetItem();
        boxItem.SetActive(true);
        boxItem.transform.position = transform.position + new Vector3(0f,1f,1.5f);
    }
    }



