using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_ScrollLoop : MonoBehaviour
{
    private Vector3 startPos;
    public float scrollAmount;
    public float scrollLimit;
    
    void Start()
    {
        startPos = this.transform.position;
    }

    void Update()
    {
        this.transform.position += Time.deltaTime * new Vector3(0f, scrollAmount, 0f);
        if((this.transform.position - startPos).magnitude > scrollLimit)
        {
            this.transform.position = startPos;
        }
    }
}
