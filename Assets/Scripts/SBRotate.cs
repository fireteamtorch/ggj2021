using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBRotate : MonoBehaviour
{
    public float angleRange;

    void Update()
    {
        this.transform.rotation = Quaternion.Euler(0f, 0f, angleRange * Mathf.Sin(Time.time * 3f));
    }
}
