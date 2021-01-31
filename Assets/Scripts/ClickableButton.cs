using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoomButtonType {  NONE, IDOL_CD, FAMILY_PHOTO, VIDEO_GAME, POTATO}

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
