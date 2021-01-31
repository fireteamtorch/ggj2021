using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Febucci.UI;

public enum DialogueSlide {
    NONE,
    IDOL_DESCRIPTION,
    IDOL_DIALOGUE,
    PHOTO_DESCRIPTION,
    PHOTO_DIALOGUE,
    GAME_DESCRIPTION,
    GAME_DIALOGUE,
    SPIRIT_BATTLE_WIN,
    SPIRIT_BATTLE_LOSE,
    HELLO,
    GOODBYE
};
public enum DialogueSpeaker { NARRATOR, PROTAGONIST, GHOST };

public class DialogueController : MonoBehaviour
{
    public TextAnimatorPlayer dialoguePlayer;
    public int nextSlideID;
    public bool isTextBoxReadyForNewText;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isTextBoxReadyForNewText && nextSlideID > 0)
            {
                StartNextDialogueBox();
            }
        }
    }

    public void StartNextDialogueBox()
    {
        isTextBoxReadyForNewText = false;
        Debug.Log(nextSlideID);
        RunSlide((DialogueSlide)nextSlideID);
    }

    public void ReportDialogueBoxFinished()
    {
        Debug.Log("Dialogue box animation finished");
        isTextBoxReadyForNewText = true;
    }

    public void RunSlide(DialogueSlide aSlide)
    {
        Debug.Log(aSlide);
        switch (aSlide)
        {
            case DialogueSlide.IDOL_DESCRIPTION:
                dialoguePlayer.ShowText("Description for idol album");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.IDOL_DIALOGUE:
                dialoguePlayer.ShowText("Ghost talks about her idol life");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.PHOTO_DESCRIPTION:
                dialoguePlayer.ShowText("Description about her family");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.PHOTO_DIALOGUE:
                dialoguePlayer.ShowText("Ghost talks about her family");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.GAME_DESCRIPTION:
                dialoguePlayer.ShowText("Description about the video game controller");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.GAME_DIALOGUE:
                dialoguePlayer.ShowText("Ghost talks about how she wanted to video game with her sister");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.SPIRIT_BATTLE_WIN:
                dialoguePlayer.ShowText("You win!");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.SPIRIT_BATTLE_LOSE:
                dialoguePlayer.ShowText("You lose!");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.HELLO:
                dialoguePlayer.ShowText("Hey!");
                nextSlideID = (int)DialogueSlide.GOODBYE;
                break;

            case DialogueSlide.GOODBYE:
                dialoguePlayer.ShowText("BYE!");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            default:
                nextSlideID = (int)DialogueSlide.NONE;
                break;
        }
    }
}
