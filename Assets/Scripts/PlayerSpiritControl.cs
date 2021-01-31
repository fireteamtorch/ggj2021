using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpiritControl : MonoBehaviour
{
    private Vector2 inputVector;
    private float moveSpeed = 5f;

    void Update()
    {
        inputVector = Vector2.zero;
        if (SpiritBattleController.Instance.isSpiritBattleActive)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                inputVector += new Vector2(-1f, 0f);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                inputVector += new Vector2(1f, 0f);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                inputVector += new Vector2(0f, 1f);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                inputVector += new Vector2(0f, -1f);
            }

            this.transform.position += new Vector3(inputVector.x, inputVector.y, 0f) * (moveSpeed * Time.deltaTime);
        }
    }
}
