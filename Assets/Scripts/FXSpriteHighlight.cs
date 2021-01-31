using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpriteHighlight : MonoBehaviour
{
    public float offsetRadius;
    public float offsetZ;
    private float prevZAngle;


    void Update()
    {
        if (this.transform.rotation.eulerAngles.z != prevZAngle)
        {
            prevZAngle = this.transform.rotation.eulerAngles.z;
            this.transform.localPosition = new Vector3(0f, 0f, offsetZ) + transform.InverseTransformDirection(Vector3.up).normalized * offsetRadius;
        }
    }
}
