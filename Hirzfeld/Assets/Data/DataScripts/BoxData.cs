using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BoxData", menuName= "Box Data")]

public class BoxData : ScriptableObject
{
    public Material boxMaterial;
    public Color boxColor;
    public Vector3 boxScale;
    public float boxSpeed;

}