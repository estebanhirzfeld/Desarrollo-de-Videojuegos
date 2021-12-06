using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> boxes;
    [SerializeField] private int boxesIndex = -1;
    [SerializeField] private Sprite imageOfAddedBox;


    public GameObject[] emptyBoxes;
    public Image item0Selected;
    public Image item1Selected;
    public Image item2Selected;

    // Start is called before the first frame update
    void Start()
    {
        boxes = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {

        // Debug.Log(boxesIndex);
        switch (boxesIndex)
        {
            case -1:
                item0Selected.enabled = false;
                item1Selected.enabled = false;
                item2Selected.enabled = true;
                boxesIndex = 2;
                break;
            case 0:
                item0Selected.enabled = true;
                item1Selected.enabled = false;
                item2Selected.enabled = false;
                break;
            case 1:
                item0Selected.enabled = false;
                item1Selected.enabled = true;
                item2Selected.enabled = false;
                break;
            case 2:
                item0Selected.enabled = false;
                item1Selected.enabled = false;
                item2Selected.enabled = true;
                break;
            default:
                item0Selected.enabled = true;
                item1Selected.enabled = false;
                item2Selected.enabled = false;
                boxesIndex = 0;
                break;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f )
        {
            boxesIndex = boxesIndex+1;
        }

        else if (Input.GetAxis("Mouse ScrollWheel") < 0f )
        {
            boxesIndex = boxesIndex-1;
        }

    }

    public void AddItem(GameObject item)
    {
        boxes.Add(item);
        imageOfAddedBox = item.GetComponent<BoxController>().boxColorImage;
        emptyBoxes[boxesIndex].transform.GetComponent<UnityEngine.UI.Image>().sprite = imageOfAddedBox;
        // anadir imagen al boxesIndex de ese momento
    }

    public GameObject GetItem()
    {
        GameObject item = boxes[boxesIndex];
        boxes.RemoveAt(boxesIndex);
        emptyBoxes[boxesIndex].transform.GetComponent<UnityEngine.UI.Image>().sprite = null;
        return item;
    }





}
