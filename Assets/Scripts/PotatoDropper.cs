using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoDropper : MonoBehaviour
{
    public GameObject potatoPrefab;
    public GameObject spawnAnchor;

    private float spawnRangeLimit = 5.2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(potatoPrefab, 
                spawnAnchor.transform.position + new Vector3(Random.Range(-spawnRangeLimit, spawnRangeLimit),0f,0f), 
                Quaternion.identity);
        }
    }
}
