using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Febucci.UI;

public enum DialogueSlide {
    NONE,
    IDOL_DESCRIPTION,
    IDOL_DIALOGUE,
    IDOL_DIALOGUE_2,
    IDOL_DIALOGUE_3,
    IDOL_DIALOGUE_4,
    IDOL_DIALOGUE_5,
    IDOL_DIALOGUE_6,
    PHOTO_DESCRIPTION,
    PHOTO_DIALOGUE,
    PHOTO_DIALOGUE_2,
    PHOTO_DIALOGUE_3,
    PHOTO_DIALOGUE_4,
    PHOTO_DIALOGUE_5,
    GAME_DESCRIPTION,
    GAME_DIALOGUE,
    GAME_DIALOGUE_2,
    GAME_DIALOGUE_3,
    GAME_DIALOGUE_4,
    GAME_DIALOGUE_5,
    GAME_DIALOGUE_6,
    GAME_DIALOGUE_7,
    POTATO_DESCRIPTION,
    POTATO_DIALOGUE,
    POTATO_DIALOGUE_2,
    SPIRIT_BATTLE_WIN,
    SPIRIT_BATTLE_LOSE,
    ENDING_GHOST,
    ENDING_GHOST_2,
    ENDING_GHOST_3,
    ENDING_GHOST_4,
    ENDING_PROTAGONIST,
    ENDING_PROTAGONIST_2,
    ENDING_PROTAGONIST_3,
    ENDING_PROTAGONIST_4,
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
                dialoguePlayer.ShowText("You... want my signature? A photo? What do you want? Everyone always wants something from me!");
                nextSlideID = (int)DialogueSlide.IDOL_DIALOGUE_2;
                break;

            case DialogueSlide.IDOL_DIALOGUE_2:
                dialoguePlayer.ShowText("I don't have time for that! I just... I don't have time for much nowadays.");
                nextSlideID = (int)DialogueSlide.IDOL_DIALOGUE_3;
                break;

            case DialogueSlide.IDOL_DIALOGUE_3:
                dialoguePlayer.ShowText("Concerts, interviews, sponsorships... emm what else, right, appearance fees, fashion line...");
                nextSlideID = (int)DialogueSlide.IDOL_DIALOGUE_4;
                break;

            case DialogueSlide.IDOL_DIALOGUE_4:
                dialoguePlayer.ShowText("I tried to send her to the most expensive private school, but she told me she didn't want to go!");
                nextSlideID = (int)DialogueSlide.IDOL_DIALOGUE_5;
                break;

            case DialogueSlide.IDOL_DIALOGUE_5:
                dialoguePlayer.ShowText("I told her she was ungrateful, but now, I think I understand.");
                nextSlideID = (int)DialogueSlide.IDOL_DIALOGUE_6;
                break;

            case DialogueSlide.IDOL_DIALOGUE_6:
                dialoguePlayer.ShowText("I think she just didn't want me to have to work so much... I wish I could tell her that.");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.PHOTO_DESCRIPTION:
                dialoguePlayer.ShowText("Description about her family");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.PHOTO_DIALOGUE:
                dialoguePlayer.ShowText("It's just me and my little sister. She's growing so fast. Hey, if you ever see her, can you tell her... nevermind.");
                nextSlideID = (int)DialogueSlide.PHOTO_DIALOGUE_2;
                break;

            case DialogueSlide.PHOTO_DIALOGUE_2:
                dialoguePlayer.ShowText("We used to watch our favorite movies together, and sing along with the characters. That's how I started singing.");
                nextSlideID = (int)DialogueSlide.PHOTO_DIALOGUE_3;
                break;

            case DialogueSlide.PHOTO_DIALOGUE_3:
                dialoguePlayer.ShowText("We moved out of our tiny apartment, but I had to live away from her.");
                nextSlideID = (int)DialogueSlide.PHOTO_DIALOGUE_4;
                break;

            case DialogueSlide.PHOTO_DIALOGUE_4:
                dialoguePlayer.ShowText("There was so much unwanted attention that came with the stardom, and I didn't want anything to happen to her.");
                nextSlideID = (int)DialogueSlide.PHOTO_DIALOGUE_5;
                break;

            case DialogueSlide.PHOTO_DIALOGUE_5:
                dialoguePlayer.ShowText("Maybe someday she'll understand, when she is older.");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.GAME_DESCRIPTION:
                dialoguePlayer.ShowText("Description about the video game controller");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.GAME_DIALOGUE:
                dialoguePlayer.ShowText("We used to play Potatoville together all the time.");
                nextSlideID = (int)DialogueSlide.GAME_DIALOGUE_2;
                break;

            case DialogueSlide.GAME_DIALOGUE_2:
                dialoguePlayer.ShowText("I would go to my sister's farm to water her garden, or catch rare butterflies with her.");
                nextSlideID = (int)DialogueSlide.GAME_DIALOGUE_3;
                break;

            case DialogueSlide.GAME_DIALOGUE_3:
                dialoguePlayer.ShowText("I used to play every day, but I logged on one day to see my garden wilted away.");
                nextSlideID = (int)DialogueSlide.GAME_DIALOGUE_4;
                break;

            case DialogueSlide.GAME_DIALOGUE_4:
                dialoguePlayer.ShowText("I didn't even realize it had been more than a week since I...");
                nextSlideID = (int)DialogueSlide.GAME_DIALOGUE_5;
                break;

            case DialogueSlide.GAME_DIALOGUE_5:
                dialoguePlayer.ShowText("When she was just a little girl, she would sit next to me, lean against my side,");
                nextSlideID = (int)DialogueSlide.GAME_DIALOGUE_6;
                break;

            case DialogueSlide.GAME_DIALOGUE_6:
                dialoguePlayer.ShowText("and cheer me on as I played different games.");
                nextSlideID = (int)DialogueSlide.GAME_DIALOGUE_7;
                break;

            case DialogueSlide.GAME_DIALOGUE_7:
                dialoguePlayer.ShowText("Whenever I won, she would do a little dance. She would always scream 'we won' as she ran around the room.");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.POTATO_DIALOGUE:
                dialoguePlayer.ShowText("All that work, all the sacrifices I made... it all ended with an angry fan throwing a potato.");
                nextSlideID = (int)DialogueSlide.POTATO_DIALOGUE_2;
                break;

            case DialogueSlide.POTATO_DIALOGUE_2:
                dialoguePlayer.ShowText("At least she is safe... I didn't take her with me anywhere with me anymore, and that kept her safe.");
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

            case DialogueSlide.ENDING_GHOST:
                dialoguePlayer.ShowText("I spread myself too thin, worked too much.");
                nextSlideID = (int)DialogueSlide.ENDING_GHOST_2;
                break;

            case DialogueSlide.ENDING_GHOST_2:
                dialoguePlayer.ShowText("I would just throw some makeup over the bags under my eyes, and go on day after day.");
                nextSlideID = (int)DialogueSlide.ENDING_GHOST_3;
                break;

            case DialogueSlide.ENDING_GHOST_3:
                dialoguePlayer.ShowText("I don't know who you are but, thank you for listening...");
                nextSlideID = (int)DialogueSlide.ENDING_GHOST_4;
                break;

            case DialogueSlide.ENDING_GHOST_4:
                dialoguePlayer.ShowText("For some reason, I feel at peace. As if I can finally go to sleep...");
                nextSlideID = (int)DialogueSlide.ENDING_PROTAGONIST;
                break;

            case DialogueSlide.ENDING_PROTAGONIST:
                dialoguePlayer.ShowText("<Ghost's name> thought she had lost her way. That she placed her career over her family.");
                nextSlideID = (int)DialogueSlide.ENDING_PROTAGONIST_2;
                break;

            case DialogueSlide.ENDING_PROTAGONIST_2:
                dialoguePlayer.ShowText("I think she needed to share her story, to get off her chest the things she never got the chance to say.");
                nextSlideID = (int)DialogueSlide.ENDING_PROTAGONIST_3;
                break;

            case DialogueSlide.ENDING_PROTAGONIST_3:
                dialoguePlayer.ShowText("She feared her little sister would never understand, and hate her for never being home.");
                nextSlideID = (int)DialogueSlide.ENDING_PROTAGONIST_4;
                break;

            case DialogueSlide.ENDING_PROTAGONIST_4:
                dialoguePlayer.ShowText("But I understood, I always did. Thank you for everything.");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            default:
                nextSlideID = (int)DialogueSlide.NONE;
                break;
        }
    }
}
