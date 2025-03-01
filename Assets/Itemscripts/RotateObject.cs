using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private Vector3 rotate = new Vector3(0, 180, 0);
    private Vector3 negativeRotate = new Vector3(0, -180, 0);
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
    public float returnX()
    {
        return transform.position.x;
    }
    public void changeInposition()
    {
        transform.position = new Vector3(2.5f, -1f, 0);
    }
    public void delayChange()
    {
        Invoke(nameof(changeInposition), 2.65f);
    }
}


