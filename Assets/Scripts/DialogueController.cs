using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Febucci.UI;
using TMPro;
using UnityEngine.UI;

public enum ConvoType
{
    IDOL_DESCRIPTION,
    IDOL_DIALOGUE,
    IDOL_FAILURE,
    PHOTO_DESCRIPTION,
    PHOTO_DIALOGUE,
    PHOTO_FAILURE,
    GAME_DESCRIPTION,
    GAME_DIALOGUE,
    GAME_FAILURE,
    FINAL_QUESTION_NOTREADY,
    FINAL_QUESTION_READY,
    FINAL_QUESTION_DIALOGUE,
    FINAL_QUESTION_FAILURE,
    ENDING_START
}

public enum DialogueSlide {
    NONE,
    IDOL_DESCRIPTION,
    IDOL_DIALOGUE,
    IDOL_DIALOGUE_2,
    IDOL_DIALOGUE_3,
    IDOL_DIALOGUE_4,
    IDOL_DIALOGUE_5,
    IDOL_DIALOGUE_6,
    IDOL_DIALOGUE_7,
    IDOL_DIALOGUE_8,
    IDOL_DIALOGUE_9,
    IDOL_DIALOGUE_10,
    IDOL_FAILURE,
    PHOTO_DESCRIPTION,
    PHOTO_DIALOGUE,
    PHOTO_DIALOGUE_2,
    PHOTO_DIALOGUE_3,
    PHOTO_DIALOGUE_4,
    PHOTO_DIALOGUE_5,
    PHOTO_DIALOGUE_6,
    PHOTO_DIALOGUE_7,
    PHOTO_FAILURE,
    GAME_DESCRIPTION,
    GAME_DIALOGUE,
    GAME_DIALOGUE_2,
    GAME_DIALOGUE_3,
    GAME_DIALOGUE_4,
    GAME_DIALOGUE_5,
    GAME_DIALOGUE_6,
    GAME_DIALOGUE_7,
    GAME_DIALOGUE_8,
    GAME_FAILURE,
    POTATO_DESCRIPTION,
    POTATO_DIALOGUE,
    POTATO_DIALOGUE_2,
    FINAL_PUZZLE_NOTREADY,
    FINAL_PUZZLE_READY,
    FINAL_PUZZLE,
    FINAL_PUZZLE_2,
    FINAL_PUZZLE_3,
    FINAL_PUZZLE_4,
    FINAL_PUZZLE_5,
    FINAL_PUZZLE_6,
    FINAL_PUZZLE_7,
    FINAL_PUZZLE_8,
    FINAL_PUZZLE_9,
    FINAL_PUZZLE_10,
    FINAL_PUZZLE_11,
    FINAL_BATTLE_FAILURE,
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
    GOODBYE,
    SHOCKED
};
public enum DialogueSpeaker { NARRATOR, PROTAGONIST, GHOST };

public class DialogueController : MonoBehaviour
{
    public static DialogueController Instance;
    public TextAnimatorPlayer dialoguePlayer;
    public int nextSlideID;
    public bool isTextBoxReadyForNewText;
    public Animator dialogueUIAnimator;
    public bool hasUIAnimated;

    public GameObject continueButton;
    public ConvoType activeConvo;
    public TextMeshProUGUI speakerLabel;
    public Image speakerImage;   

    private void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
        if (isTextBoxReadyForNewText && Input.GetMouseButtonDown(0))
        {
            if(nextSlideID == (int)DialogueSlide.NONE)
            {
                //Close the dialogue
                CloseDialogueUI();
            }else if (nextSlideID > 0)
            {
                StartNextDialogueBox();
            }
        }

        if(isTextBoxReadyForNewText && !continueButton.activeSelf)
        {
            continueButton.SetActive(true);
        }

        if (!isTextBoxReadyForNewText && continueButton.activeSelf)
        {
            continueButton.SetActive(false);
        }
    }

    public void StartConvo(ConvoType aConvo)
    {
        activeConvo = aConvo;
        isTextBoxReadyForNewText = true;
        switch (aConvo)
        {
            case ConvoType.IDOL_DESCRIPTION:
                nextSlideID = (int)DialogueSlide.IDOL_DESCRIPTION;
                break;
            case ConvoType.IDOL_DIALOGUE:
                nextSlideID = (int)DialogueSlide.IDOL_DIALOGUE;
                break;
            case ConvoType.IDOL_FAILURE:
                nextSlideID = (int)DialogueSlide.IDOL_FAILURE;
                break;
            case ConvoType.PHOTO_DESCRIPTION:
                nextSlideID = (int)DialogueSlide.PHOTO_DESCRIPTION;
                break;
            case ConvoType.PHOTO_DIALOGUE:
                nextSlideID = (int)DialogueSlide.PHOTO_DIALOGUE;
                break;
            case ConvoType.PHOTO_FAILURE:
                nextSlideID = (int)DialogueSlide.PHOTO_FAILURE;
                break;
            case ConvoType.GAME_DESCRIPTION:
                nextSlideID = (int)DialogueSlide.GAME_DESCRIPTION;
                break;
            case ConvoType.GAME_DIALOGUE:
                nextSlideID = (int)DialogueSlide.GAME_DIALOGUE;
                break;
            case ConvoType.GAME_FAILURE:
                nextSlideID = (int)DialogueSlide.GAME_FAILURE;
                break;

            case ConvoType.FINAL_QUESTION_DIALOGUE:
                nextSlideID = (int)DialogueSlide.FINAL_PUZZLE;
                break;
            case ConvoType.FINAL_QUESTION_NOTREADY:
                nextSlideID = (int)DialogueSlide.FINAL_PUZZLE_NOTREADY;
                break;
            case ConvoType.FINAL_QUESTION_READY:
                nextSlideID = (int)DialogueSlide.FINAL_PUZZLE_READY;
                break;
            case ConvoType.FINAL_QUESTION_FAILURE:
                nextSlideID = (int)DialogueSlide.FINAL_BATTLE_FAILURE;
                break;

            case ConvoType.ENDING_START:
                nextSlideID = (int)DialogueSlide.ENDING_PROTAGONIST;
                break;
        }
        StartNextDialogueBox();
    }

    public void StartNextDialogueBox()
    {
        if (!hasUIAnimated)
        {
            hasUIAnimated = true;
            dialogueUIAnimator.SetTrigger("show");
        }

        isTextBoxReadyForNewText = false;
        Debug.Log(nextSlideID);
        RunSlide((DialogueSlide)nextSlideID);
    }

    public void CloseDialogueUI()
    {
        isTextBoxReadyForNewText = false;
        dialogueUIAnimator.SetTrigger("hide");
        hasUIAnimated = false;
        RoomController.Instance.ReportConvoFinished(activeConvo);
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
                dialoguePlayer.ShowText("Ahh...  I don't want to talk about that CD.");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.IDOL_DIALOGUE:
                dialoguePlayer.ShowText("This was my second solo album.");
                nextSlideID = (int)DialogueSlide.IDOL_DIALOGUE_2;
                break;

            case DialogueSlide.IDOL_DIALOGUE_2:
                dialoguePlayer.ShowText(" It one got all the way up to #3 on the billboards, and my idol career really took off after this.");
                nextSlideID = (int)DialogueSlide.IDOL_DIALOGUE_3;
                break;

            case DialogueSlide.IDOL_DIALOGUE_3:
                dialoguePlayer.ShowText("After all of my hard work, I felt like I'd finally made it.");
                nextSlideID = (int)DialogueSlide.IDOL_DIALOGUE_4;
                break;

            case DialogueSlide.IDOL_DIALOGUE_4:
                dialoguePlayer.ShowText("Do you think I was living a glamorous life? Maybe it seemed like that to you.");
                nextSlideID = (int)DialogueSlide.IDOL_DIALOGUE_5;
                break;

            case DialogueSlide.IDOL_DIALOGUE_5:
                dialoguePlayer.ShowText("I always had to put on my happy face, but in reality I was barely keeping it together.");
                nextSlideID = (int)DialogueSlide.IDOL_DIALOGUE_6;
                break;

            case DialogueSlide.IDOL_DIALOGUE_6:
                dialoguePlayer.ShowText("Every day was just one obligation after another. Meetings with agents, fan signings, interviews, concerts.");
                nextSlideID = (int)DialogueSlide.IDOL_DIALOGUE_7;
                break;

            case DialogueSlide.IDOL_DIALOGUE_7:
                dialoguePlayer.ShowText("Everyone always wanted something from me.");
                nextSlideID = (int)DialogueSlide.IDOL_DIALOGUE_8;
                break;

            case DialogueSlide.IDOL_DIALOGUE_8:
                dialoguePlayer.ShowText("I felt like I was living someone else's life, with no time for myself or people I cared about anymore.");
                nextSlideID = (int)DialogueSlide.IDOL_DIALOGUE_9;
                break;

            case DialogueSlide.IDOL_DIALOGUE_9:
                dialoguePlayer.ShowText("Maybe you think I became an idol for the attention, or the money.");
                nextSlideID = (int)DialogueSlide.IDOL_DIALOGUE_10;
                break;

            case DialogueSlide.IDOL_DIALOGUE_10:
                dialoguePlayer.ShowText("But I really just wanted to provide a better life for my sister. She had always been my biggest fan. If only I had...");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.IDOL_FAILURE:
                dialoguePlayer.ShowText("You've got the wrong idea. I wasn't doing this for the reasons you think.");
                nextSlideID = (int)DialogueSlide.NONE;
                break;
                
            case DialogueSlide.PHOTO_DESCRIPTION:
                dialoguePlayer.ShowText("It's our family photo... I don't want to look at it.");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.PHOTO_DIALOGUE:
                dialoguePlayer.ShowText("This is a photo of our family. It's just been me and my sister Yuu for so long. She's growing up so fast now...");
                nextSlideID = (int)DialogueSlide.PHOTO_DIALOGUE_2;
                break;

            case DialogueSlide.PHOTO_DIALOGUE_2:
                dialoguePlayer.ShowText("When we were younger, we always used to watch all of the idol concerts on TV and sing along.");
                nextSlideID = (int)DialogueSlide.PHOTO_DIALOGUE_3;
                break;

            case DialogueSlide.PHOTO_DIALOGUE_3:
                dialoguePlayer.ShowText("That's where I first discovered my talent for singing. She always believed that I could be an idol one day.");
                nextSlideID = (int)DialogueSlide.PHOTO_DIALOGUE_4;
                break;

            case DialogueSlide.PHOTO_DIALOGUE_4:
                dialoguePlayer.ShowText("After I made it as an idol, I had to move out on my own, away from her.");
                nextSlideID = (int)DialogueSlide.PHOTO_DIALOGUE_5;
                break;

            case DialogueSlide.PHOTO_DIALOGUE_5:
                dialoguePlayer.ShowText("There was so much unwanted attention that came with my new life, and I didn't want anything to happen to her.");
                nextSlideID = (int)DialogueSlide.PHOTO_DIALOGUE_6;
                break;

            case DialogueSlide.PHOTO_DIALOGUE_6:
                dialoguePlayer.ShowText("I think she resented me for it at the time, but...maybe she'll understand now.");
                nextSlideID = (int)DialogueSlide.PHOTO_DIALOGUE_7;
                break;

            case DialogueSlide.PHOTO_DIALOGUE_7:
                dialoguePlayer.ShowText("Hey...if you ever get a chance to see my sister, can you tell her - ah, never mind.");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.PHOTO_FAILURE:
                dialoguePlayer.ShowText("Sorry...I don't want to talk about her.");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.GAME_DESCRIPTION:
                dialoguePlayer.ShowText("The PlayBox 2 is all dusty... I'd rather not talk about it.");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.GAME_DIALOGUE:
                dialoguePlayer.ShowText("It's Potatoville. Brings back memories...");
                nextSlideID = (int)DialogueSlide.GAME_DIALOGUE_2;
                break;

            case DialogueSlide.GAME_DIALOGUE_2:
                dialoguePlayer.ShowText("We didn't have a lot of money growing up, but I saved up from my part-time job and bought a PlayBox 2.");
                nextSlideID = (int)DialogueSlide.GAME_DIALOGUE_3;
                break;

            case DialogueSlide.GAME_DIALOGUE_3:
                dialoguePlayer.ShowText("When my sister was a little girl, she would sit next to me and cheer me on as I played.");
                nextSlideID = (int)DialogueSlide.GAME_DIALOGUE_4;
                break;

            case DialogueSlide.GAME_DIALOGUE_4:
                dialoguePlayer.ShowText("Whenever I won, she would do a little dance and scream 'we won' as she ran around the room.");
                nextSlideID = (int)DialogueSlide.GAME_DIALOGUE_5;
                break;

            case DialogueSlide.GAME_DIALOGUE_5:
                dialoguePlayer.ShowText("Even after I started my career, Yuu and I used to play Potatoville together every night.");
                nextSlideID = (int)DialogueSlide.GAME_DIALOGUE_6;
                break;

            case DialogueSlide.GAME_DIALOGUE_6:
                dialoguePlayer.ShowText("I would go to my sister's farm to water her garden, or catch rare butterflies with her.");
                nextSlideID = (int)DialogueSlide.GAME_DIALOGUE_7;
                break;

            case DialogueSlide.GAME_DIALOGUE_7:
                dialoguePlayer.ShowText("But then I stopped having time. I logged on one day to see that my garden had wilted away.");
                nextSlideID = (int)DialogueSlide.GAME_DIALOGUE_8;
                break;

            case DialogueSlide.GAME_DIALOGUE_8:
                dialoguePlayer.ShowText("I didn't even realize it had been months since I...");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.GAME_FAILURE:
                dialoguePlayer.ShowText("I don't see why we need to disuss this...");
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

            case DialogueSlide.FINAL_PUZZLE_NOTREADY:
                dialoguePlayer.ShowText("My last regret? ...You don't know enough about my suffering.");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.FINAL_PUZZLE_READY:
                dialoguePlayer.ShowText("My regret? ...Maybe you know enough now to see.");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.FINAL_PUZZLE:
                dialoguePlayer.ShowText("My sister and I used to argue about what private school she should go to.");
                nextSlideID = (int)DialogueSlide.FINAL_PUZZLE_2;
                break;

            case DialogueSlide.FINAL_PUZZLE_2:
                dialoguePlayer.ShowText("I tried to send her to the most expensive one, but she told me she didn't want to go!");
                nextSlideID = (int)DialogueSlide.FINAL_PUZZLE_3;
                break;

            case DialogueSlide.FINAL_PUZZLE_3:
                dialoguePlayer.ShowText("I told her she was ungrateful, but I think I understand now.");
                nextSlideID = (int)DialogueSlide.FINAL_PUZZLE_4;
                break;

            case DialogueSlide.FINAL_PUZZLE_4:
                dialoguePlayer.ShowText("I think she saw how stressed I was, and didn't want me to work so much.");
                nextSlideID = (int)DialogueSlide.FINAL_PUZZLE_5;
                break;

            case DialogueSlide.FINAL_PUZZLE_5:
                dialoguePlayer.ShowText("I wish I could take my words back...");
                nextSlideID = (int)DialogueSlide.FINAL_PUZZLE_6;
                break;

            case DialogueSlide.FINAL_PUZZLE_6:
                dialoguePlayer.ShowText("I used to think that everything was worth it - all the work, stress, and isolation");
                nextSlideID = (int)DialogueSlide.FINAL_PUZZLE_7;
                break;

            case DialogueSlide.FINAL_PUZZLE_7:
                dialoguePlayer.ShowText("- so that I could give Yuu a better life.");
                nextSlideID = (int)DialogueSlide.FINAL_PUZZLE_8;
                break;

            case DialogueSlide.FINAL_PUZZLE_8:
                dialoguePlayer.ShowText("Looking back, I wish I could have just spent that time with my sister instead.");
                nextSlideID = (int)DialogueSlide.FINAL_PUZZLE_9;
                break;

            case DialogueSlide.FINAL_PUZZLE_9:
                dialoguePlayer.ShowText("I was so focused on doing what I thought would be best for her that I lost sight of what was really important.");
                nextSlideID = (int)DialogueSlide.FINAL_PUZZLE_10;
                break;

            case DialogueSlide.FINAL_PUZZLE_10:
                dialoguePlayer.ShowText("I don't know who you are, but thank you for listening.");
                // set happy
                nextSlideID = (int)DialogueSlide.FINAL_PUZZLE_11;
                break;

            case DialogueSlide.FINAL_PUZZLE_11:
                dialoguePlayer.ShowText("I feel at peace now, talking things through with you. I think... I can finally rest.");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            case DialogueSlide.FINAL_BATTLE_FAILURE:
                dialoguePlayer.ShowText("I've told you so much...");
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
                /*
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
                */

            case DialogueSlide.ENDING_PROTAGONIST:
                dialoguePlayer.ShowText("Rei thought she had lost her way. That she placed her career over her family.");
                SetSpeakerLabel(DialogueSpeaker.PROTAGONIST);
                SetSpeakerSprite(DialogueSpeaker.PROTAGONIST);
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

    public void SetSpeakerLabel(DialogueSpeaker aSpeaker)
    {
        switch (aSpeaker)
        {
            case DialogueSpeaker.GHOST:
                speakerLabel.text = "Rei";
                break;

            case DialogueSpeaker.PROTAGONIST:
                speakerLabel.text = "Spirit Detective";
                break;

            case DialogueSpeaker.NARRATOR:
                speakerLabel.text = "";
                break;
        }
    }

    public void SetSpeakerSprite(DialogueSpeaker aSpeaker)
    {
        switch (aSpeaker)
        {
            case DialogueSpeaker.GHOST:
                speakerImage.gameObject.SetActive(true);
                break;

            default:
                speakerImage.gameObject.SetActive(false);
                break;
        }
    }
}
