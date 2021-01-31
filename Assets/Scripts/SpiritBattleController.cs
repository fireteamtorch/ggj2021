using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpiritBattleType { 
    NONE,
    IDOL_CD,
    IDOL_CD_WITH_FAMILY,
    FAMILY_PHOTO,
    VIDEO_GAME,
    POTATO
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
            //control the player character



            
        }
    }

    public void StartSpiritBattle(SpiritBattleType aBattleType)
    {
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

            default:
                return null;
        }
    }

    public void PlayerSuccess()
    {

    }

    public void PlayerDied()
    {

    }
}
