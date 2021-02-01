using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpiritBattleType { 
    NONE,
    IDOL_CD,
    IDOL_CD_WITH_FAMILY,
    FAMILY_PHOTO,
    VIDEO_GAME,
    POTATO,
    FINAL_BATTLE_NOTREADY,
    FINAL_BATTLE_READY
}

public class SpiritBattleController : MonoBehaviour
{
    public static SpiritBattleController Instance;
    public bool isSpiritBattleActive;
    public SpiritBattleType activeBattle;
    public GameObject spawnAnchor;
    public Animator SpiritMaskAnimator;
    [Header("Battle Prefabs")]
    public GameObject SB_IdolCD;
    public GameObject SB_IdolCD_withFamily;
    public GameObject SB_FamilyPhoto;
    public GameObject SB_VideoGameConsole;
    public GameObject SB_Potato;
    public GameObject SB_FinalBattle_NotReady;
    public GameObject SB_FinalBattle_Ready;
    [Header("Current Battle Objects")]
    public GameObject spawnedSpiritBattle;
    public PlayerSpiritControl playerSpirit;
    public GhostSpiritControl ghostSpirit;
 
    private void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
        if (isSpiritBattleActive)
        {

            
        }
    }

    public void StartSpiritBattle(SpiritBattleType aBattleType)
    {
        if(spawnedSpiritBattle != null){
            Destroy(spawnedSpiritBattle);
            spawnedSpiritBattle = null;
        }
        if (RoomController.Instance.isAcceptingRoomButtons == true)
        {
            RoomController.Instance.isAcceptingRoomButtons = false;
        }
        AudioManager.instance.FocusAudioLoud();
        spawnedSpiritBattle = Instantiate(GetSpiritBattlePrefab(aBattleType), Vector3.zero, Quaternion.identity);
        spawnedSpiritBattle.transform.parent = spawnAnchor.transform;
        isSpiritBattleActive = true;
        activeBattle = aBattleType;
        SpiritMaskAnimator.SetTrigger("show");
        playerSpirit = spawnedSpiritBattle.GetComponentInChildren<PlayerSpiritControl>();
        ghostSpirit = spawnedSpiritBattle.GetComponentInChildren<GhostSpiritControl>();
    }

    public GameObject GetSpiritBattlePrefab(SpiritBattleType aBattle)
    {
        switch (aBattle)
        {
            case SpiritBattleType.IDOL_CD:
                return SB_IdolCD;
            case SpiritBattleType.IDOL_CD_WITH_FAMILY:
                return SB_IdolCD_withFamily;
            case SpiritBattleType.POTATO:
                return SB_Potato;
            case SpiritBattleType.FAMILY_PHOTO:
                return SB_FamilyPhoto;
            case SpiritBattleType.VIDEO_GAME:
                return SB_VideoGameConsole;

            case SpiritBattleType.FINAL_BATTLE_NOTREADY:
                return SB_FinalBattle_NotReady;
            case SpiritBattleType.FINAL_BATTLE_READY:
                return SB_FinalBattle_Ready;

            default:
                return null;
        }
    }

    public void PlayerSuccess()
    {
        if (isSpiritBattleActive)
        {
            Debug.Log("Hoorayyyyyyyyyyy");
            isSpiritBattleActive = false;
            SpiritMaskAnimator.SetTrigger("hide");
            RoomController.Instance.ReportSpiritBattleFinished(activeBattle, true);
        }
    }

    public void PlayerDied()
    {
        if (isSpiritBattleActive)
        {
            Debug.Log("HECKIN' BIG SAD");
            isSpiritBattleActive = false;
            SpiritMaskAnimator.SetTrigger("hide");
            RoomController.Instance.ReportSpiritBattleFinished(activeBattle, false);
        }
    }
}
