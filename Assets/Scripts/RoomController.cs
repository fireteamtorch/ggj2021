using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public static RoomController Instance;
    public bool isAcceptingRoomButtons;

    public bool hasIdolCDBeenChecked;
    public bool hasFamilyPhotoBeenChecked;
    public bool hasVideoGameBeenChecked;

    public bool hasFinishedSB_IdolCD;
    public bool hasFinishedSB_FamilyPhoto;
    public bool hasFinishedSB_VideoGameConsole;

    public DialogueController dialogueCtrl;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        isAcceptingRoomButtons = true;
    }

    public void ReportRoomButtonPressed(RoomButtonType aButtonType)
    {
        if (isAcceptingRoomButtons)
        {
            Debug.Log("Button: " + aButtonType.ToString());
            switch (aButtonType)
            {
                case RoomButtonType.IDOL_CD:
                    if (!hasFinishedSB_IdolCD)
                    {
                        DialogueController.Instance.StartConvo(ConvoType.IDOL_DESCRIPTION);
                    }
                    else
                    {
                        DialogueController.Instance.StartConvo(ConvoType.IDOL_DIALOGUE);
                    }

                    break;

                case RoomButtonType.FAMILY_PHOTO:
                    if (!hasFinishedSB_FamilyPhoto)
                    {
                        DialogueController.Instance.StartConvo(ConvoType.PHOTO_DESCRIPTION);
                    }
                    else
                    {
                        DialogueController.Instance.StartConvo(ConvoType.PHOTO_DIALOGUE);
                    }
                    break;

                case RoomButtonType.VIDEO_GAME:
                    if (!hasFinishedSB_VideoGameConsole)
                    {
                        DialogueController.Instance.StartConvo(ConvoType.GAME_DESCRIPTION);
                    }
                    else
                    {
                        DialogueController.Instance.StartConvo(ConvoType.GAME_DIALOGUE);
                    }
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

                hasIdolCDBeenChecked = true;
                if (hasFamilyPhotoBeenChecked)
                {
                    SpiritBattleController.Instance.StartSpiritBattle(SpiritBattleType.IDOL_CD_WITH_FAMILY);
                }
                else
                {
                    SpiritBattleController.Instance.StartSpiritBattle(SpiritBattleType.IDOL_CD);
                }
                break;

            case ConvoType.PHOTO_DESCRIPTION:
                hasFamilyPhotoBeenChecked = true;
                SpiritBattleController.Instance.StartSpiritBattle(SpiritBattleType.FAMILY_PHOTO);
                break;

            case ConvoType.GAME_DESCRIPTION:
                hasVideoGameBeenChecked = true;
                SpiritBattleController.Instance.StartSpiritBattle(SpiritBattleType.VIDEO_GAME);
                break;
              

            default:
                break;
        }
    }

    public void ReportSpiritBattleFinished(SpiritBattleType aBattleType, bool is_victory)
    {
        switch (aBattleType)
        {
            case SpiritBattleType.IDOL_CD:
            case SpiritBattleType.IDOL_CD_WITH_FAMILY:
                Debug.Log("Fight idol cd");
                if (is_victory)
                {
                    Debug.Log("Win");
                    DialogueController.Instance.StartConvo(ConvoType.IDOL_DIALOGUE);
                    hasFinishedSB_IdolCD = true;
                }
                else
                {
                    DialogueController.Instance.StartConvo(ConvoType.IDOL_FAILURE);
                }
                break;

            case SpiritBattleType.FAMILY_PHOTO:
                Debug.Log("Fight Family Photo");
                if (is_victory)
                {
                    Debug.Log("Win");
                    DialogueController.Instance.StartConvo(ConvoType.PHOTO_DIALOGUE);
                    hasFinishedSB_FamilyPhoto = true;
                }
                else
                {
                    DialogueController.Instance.StartConvo(ConvoType.IDOL_FAILURE);
                }
                break;

            case SpiritBattleType.VIDEO_GAME:
                Debug.Log("Fight video game");
                if (is_victory)
                {
                    Debug.Log("Win");
                    DialogueController.Instance.StartConvo(ConvoType.GAME_DIALOGUE);
                    hasFinishedSB_FamilyPhoto = true;
                }
                else
                {
                    DialogueController.Instance.StartConvo(ConvoType.GAME_FAILURE);
                }
                break;
        }
    }
}
