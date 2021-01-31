using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_Pulse : MonoBehaviour
{
    private Vector3 startScale;
    private float offset;
    public float scaleFactor = 1f;
    public float pulseRateFactor = 1f;

    void Start()
    {
        startScale = this.transform.localScale;
        offset = Random.Range(0f, 1f);
    }

    void Update()
    {
        this.transform.localScale = Vector3.Lerp(startScale, startScale * (scaleFactor), (Mathf.Sin((Time.time * pulseRateFactor) + offset) / 2f) + 0.5f);
    }
}
