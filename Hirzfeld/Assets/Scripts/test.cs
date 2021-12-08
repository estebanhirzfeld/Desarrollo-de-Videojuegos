using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    [SerializeField] protected float changingValue;
    [SerializeField] protected float overflowValue;
    [SerializeField] protected bool overflow;
    [SerializeField] protected GameObject box;

    // Start is called before the first frame update
    public virtual void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {
        Dimmer();

        Debug.Log((int)changingValue);
    }


    public virtual void Dimmer()
    {
        if (changingValue > overflowValue)
        {
            overflow = false;
        }
        else if (changingValue < 0)
        {
            overflow = true;
        }

        if (overflow)
        {
            changingValue += 1 * Time.deltaTime;  // Increment
            box.transform.localScale += new Vector3(0f, 0f, changingValue) * Time.deltaTime;
        }
        else
        {
            changingValue -= 1 * Time.deltaTime;  // Decrement
            box.transform.localScale -= new Vector3(0f, 0f, changingValue) * Time.deltaTime;
        }
    }
}
