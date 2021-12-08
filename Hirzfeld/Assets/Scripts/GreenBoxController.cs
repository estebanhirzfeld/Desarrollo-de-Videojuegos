using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBoxController : test
{
    [SerializeField] protected BoxData data;

    public override void Start()
    {
        data.boxMaterial.color = data.boxColor;
    }


    public override void Dimmer()
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
            box.transform.localScale += new Vector3(changingValue, changingValue, changingValue) * Time.deltaTime;

        }
        else
        {
            changingValue -= 1 * Time.deltaTime;  // Decrement
            box.transform.localScale -= new Vector3(changingValue, changingValue, changingValue) * Time.deltaTime;
        }
    }

}
