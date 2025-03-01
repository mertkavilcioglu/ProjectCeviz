using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector3 rotate=new Vector3(0,180,0);
    public Vector3 negativeRotate = new Vector3(0, -180, 0);
    public void ObjectRotate()
    {
        transform.Rotate(rotate);
    }
    public void NegativeObjectRotate()
    {
        transform.Rotate(negativeRotate);
    }
    public void teleport()
    {
        transform.position = new Vector3(9.4f, -1f, 0);
    }
}
