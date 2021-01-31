using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public bool isAcceptingRoomButtons;
    public bool hasKnifeBeenChecked;


    void Start()
    {
        isAcceptingRoomButtons = true;
    }

    void Update()
    {
        
    }

    public void ReportRoomButtonPressed(RoomButtonType aButtonType)
    {
        if (isAcceptingRoomButtons)
        {
            Debug.Log("Button: " + aButtonType.ToString());
            switch (aButtonType)
            {
                case RoomButtonType.KNIFE:
                    if (!hasKnifeBeenChecked)
                    {
                        // DIALOGUE FOR KNIFE DESCRIPT HERE
                        hasKnifeBeenChecked = true;
                    }
                    else
                    {
                        // DIALOGUE FOR KNIFE REVEAL
                    }

                    break;

                default:
                    break;
            }
        }
    }
}
