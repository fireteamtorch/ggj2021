using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroController : MonoBehaviour
{
    [SerializeField] private TextMesh theEnd;
    private void Start()
    {
        theEnd.color = Color.clear;
    }

    void Update()
    {
        theEnd.color = Color.Lerp(theEnd.color, Color.white, Time.deltaTime);
    }
}
