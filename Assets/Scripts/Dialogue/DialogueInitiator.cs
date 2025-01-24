using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInitiator : MonoBehaviour
{
    [SerializeField] DialogueBox dialogueBox;
    //KeyCode interactKey = KeyCode.E;
    [SerializeField] List<string> lines;
    [SerializeField] List<float> lineSpeeds;
    


    public void StartConversation()
    {
        dialogueBox.text = lines;
        dialogueBox.textSpeeds = lineSpeeds;
        dialogueBox.gameObject.SetActive(true);
        
    }
}
