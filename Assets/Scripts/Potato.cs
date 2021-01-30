using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : MonoBehaviour
{
    public int x = 42;
    public SpriteRenderer renderer;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("POTATO");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            renderer.color = Color.red;
            audioSource.Play();
        }
    }
}
