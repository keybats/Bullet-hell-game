using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInitiator : MonoBehaviour
{
    [SerializeField] DialogueBox dialogueBox;
    KeyCode interactKey = KeyCode.E;
    [SerializeField] List<string> lines;
    [SerializeField] List<float> lineSpeeds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(interactKey))
        {
            
            StartConversation();
        }
        */
    }

    public void StartConversation()
    {
        dialogueBox.text = lines;
        dialogueBox.textSpeeds = lineSpeeds;
        dialogueBox.gameObject.SetActive(true);
        
    }
}
