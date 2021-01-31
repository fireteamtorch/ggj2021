using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Febucci.UI;

public enum DialogueSlide { NONE, C1_HELLO, C1_HOWSITGOING, C1_GOODBYE, C2_WHATKNIFE}

public class DialogueController : MonoBehaviour
{
    public TextAnimatorPlayer dialoguePlayer;
    public int nextSlideID;
    public bool isTextBoxReadyForNewText;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(isTextBoxReadyForNewText && nextSlideID > 0)
            {
                StartNextDialogueBox();
            }
        }
    }

    public void StartNextDialogueBox()
    {
        isTextBoxReadyForNewText = false;
        RunSlide((DialogueSlide)nextSlideID);
    }

    public void ReportDialogueBoxFinished()
    {
        Debug.Log("Dialogue box animation finished");
        isTextBoxReadyForNewText = true;
    }

    public void RunSlide(DialogueSlide aSlide)
    {
        switch (aSlide)
        {
            case DialogueSlide.C1_HELLO:
                dialoguePlayer.ShowText("Hey, I'm a ghost!!");
                nextSlideID = (int)DialogueSlide.C1_GOODBYE;
                break;

            case DialogueSlide.C1_GOODBYE:
                dialoguePlayer.ShowText("Cya");
                nextSlideID = (int)DialogueSlide.NONE;
                break;

            default:
                nextSlideID = (int)DialogueSlide.NONE;
                break;
        }
    }
}
