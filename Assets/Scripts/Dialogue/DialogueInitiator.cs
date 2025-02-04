using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInitiator : MonoBehaviour
{
    [SerializeField] DialogueBox dialogueBox;

    [SerializeField] List<DialoguePart> dialogueParts;
    


    public void StartConversation(int dialogueIndex)
    {
        dialogueBox.text = dialogueParts[dialogueIndex].lines;
        dialogueBox.textSpeeds = dialogueParts[dialogueIndex].lineSpeeds;
        
        dialogueBox.endsWithButton = dialogueParts[dialogueIndex].endsWithChoice;
        dialogueBox.nextPart = dialogueParts[dialogueIndex].nextPart;
        dialogueBox.dialogueOptionNames = dialogueParts[dialogueIndex].dialogueOptionName;
        
        dialogueBox.endsWithFight = dialogueParts[dialogueIndex].endsWithFight;
        dialogueBox.fightInitiator = dialogueParts[dialogueIndex].fightInitiator;

        dialogueBox.gameObject.SetActive(true);
        dialogueBox.StartDialogue(gameObject.GetComponent<DialogueInitiator>());
    }
}
