using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInitiator : MonoBehaviour
{
    [SerializeField] DialogueBox dialogueBox;
    [SerializeField] List<string> lines;
    [SerializeField] List<float> lineSpeeds;
    [SerializeField] bool endsWithChoice = false;
    [ConditionalHide("endsWithChoice", true)] [SerializeField] List<DialogueInitiator> nextPart;
    [ConditionalHide("endsWithChoice", true)] [SerializeField] List<string> dialogueOptionName;
    [SerializeField] bool endsWithFight = false;
    [ConditionalHide("endsWithFight", true)] [SerializeField] FightInitiator fightInitiator;



    public void StartConversation()
    {
        dialogueBox.text = lines;
        dialogueBox.textSpeeds = lineSpeeds;
        
        dialogueBox.endsWithButton = endsWithChoice;
        dialogueBox.nextPart = this.nextPart;
        dialogueBox.dialogueOptionNames = this.dialogueOptionName;
        

        dialogueBox.endsWithFight = this.endsWithFight;
        dialogueBox.fightInitiator = this.fightInitiator;

        dialogueBox.gameObject.SetActive(true);
        dialogueBox.StartDialogue();
    
             
    }
}
