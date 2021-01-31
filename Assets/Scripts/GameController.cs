using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Febucci.UI;

public class GameController : MonoBehaviour
{

    public string tempString;

    void Start()
    {
        tempString = "Testing dialogue string for the charcter text and wrapping and run on sentences.";
        //dialoguePlayer.ShowText(tempString);
    }

    void Update()
    {
       
    }

    public void ReportDialogueFinished()
    {
        Debug.Log("Dialogue done");
    }
}
