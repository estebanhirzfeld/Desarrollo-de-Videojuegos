using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBoxController : test
{


    public override void Update()
    {
        base.Update();
        // box.transform.position += new Vector3(changingValue * 0.2f, changingValue * 0.2f,changingValue * 0.2f) * 2 * Time.deltaTime;
        // box.transform.Translate(new Vector3(changingValue * 0.2f, changingValue * 0.2f,changingValue * 0.2f) * 2 * Time.deltaTime);

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
            box.transform.position += new Vector3(changingValue * 0.2f, changingValue * 0.2f,changingValue * 0.2f) * 2 * Time.deltaTime;
            box.transform.localScale += new Vector3(changingValue * 0.5f, changingValue * 0.5f, 0) * Time.deltaTime;

        }
        else
        {
            changingValue -= 1 * Time.deltaTime;  // Decrement
            box.transform.position -= new Vector3(changingValue * 0.2f, changingValue * 0.2f,changingValue * 0.2f) * 2 * Time.deltaTime;
            box.transform.localScale -= new Vector3(changingValue * 0.5f, changingValue * 0.5f, 0) * Time.deltaTime;
        }
    }

}
