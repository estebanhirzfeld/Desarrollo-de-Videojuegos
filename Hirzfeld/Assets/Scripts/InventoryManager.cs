using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> boxes;
    [SerializeField] private int boxesIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        boxes = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {

        if ((boxesIndex > 2)||(boxesIndex < 0))
        {
            boxesIndex = 0;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f )
        {
            boxesIndex = boxesIndex+1;
        }

        else if (Input.GetAxis("Mouse ScrollWheel") < 0f )
        {
            boxesIndex = boxesIndex-1;
        }

        // Debug.Log(boxesIndex);
    }

    public void AddItem(GameObject item)
    {
        boxes.Add(item);
    }

    public GameObject GetItem()
    {
        GameObject item = boxes[boxesIndex];
        boxes.RemoveAt(boxesIndex);
        return item;
    }





}
