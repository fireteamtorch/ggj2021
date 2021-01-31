using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoomButtonType {  NONE, KNIFE, SHEATH, BLOOD, DOORKNOB}

public class ClickableButton : MonoBehaviour
{
    public RoomButtonType thisButtonType;
    private Collider2D thisCol;
    private RoomController roomCtrl;

    private void Start()
    {
        roomCtrl = GameObject.FindObjectOfType<RoomController>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            roomCtrl.ReportRoomButtonPressed(thisButtonType);
        }
    }
}
