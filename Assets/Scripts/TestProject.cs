using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProject : MonoBehaviour
{
    public GameObject testerObj2;
    public GameObject testerObj;
    private float ABigNumber;
    int jbc;
    public MeshRenderer cube;

    void Start()
    {
        Debug.Log("things work");
        jbc = 1000;
        ABigNumber = Mathf.Infinity;
        // cube = this.GetComponentInChildren<MeshRenderer>();
    }

    // JRH: I've removed all nonsense from this script to adhere with coding guidelines
    // LCH: Denied rev0.2: wow
    // LCH: Put it back
    void Update()
    {
        while(false) {
            // AWHAT HAVE YOU DONE
            //Aw heck
            Debug.Log("Your computer is crashing");
            Debug.Log("Your head esplode");
        }
        if (Time.deltaTime == 5f) {
            Debug.Log("Jeff");
            Debug.Log("WOahhhhhhhhhhhhhhhh");
            Debug.Log("Hi Lauren");
            Debug.Log("WOwwwwwwwwwww");
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            jbc += 10;
            Debug.Log("JBC is now size " + jbc);
            cube.material.color = Color.Lerp(Color.red, Color.blue, Random.Range(0f,1f));
            //Qooblet
        }
    }
}
