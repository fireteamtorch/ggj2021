using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public static RoomController Instance;
    public bool isAcceptingRoomButtons;

    public bool hasIdolCDBeenChecked;
    public bool hasFamilyPhotoBeenChecked;

    public DialogueController dialogueCtrl;

    private void Awake()
    {
        Instance = this;
    }

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
                case RoomButtonType.IDOL_CD:
                    DialogueController.Instance.StartConvo(ConvoType.IDOL_DESCRIPTION);
                    /*
                    if (!hasFamilyPhotoBeenChecked)
                    {
                        // DIALOGUE FOR KNIFE DESCRIPT HERE
                        
                    }
                    else
                    {
                        // DIALOGUE FOR KNIFE REVEAL
                    }*/

                    break;

                default:
                    break;
            }
        }
    }

    public void ReportConvoFinished(ConvoType convo)
    {
        switch (convo)
        {
            case ConvoType.IDOL_DESCRIPTION:
                SpiritBattleController.Instance.StartSpiritBattle(SpiritBattleType.IDOL_CD);
                break;
        }
    }

    public void ReportSpiritBattleFinished(SpiritBattleType aBattleType)
    {
        switch (aBattleType)
        {
            case SpiritBattleType.IDOL_CD_WITH_FAMILY:
                break;
        }
    }
}
