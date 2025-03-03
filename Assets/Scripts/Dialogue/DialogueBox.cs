using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueBox : MonoBehaviour
{
    DialogueInitiator dialogueInitiator;
    public List<string> text;
    public List<float> textSpeeds;
    public bool endsWithButton;
    public List<int> nextPart;
    public List<string> dialogueOptionNames;
    public bool endsWithFight;
    public FightInitiator fightInitiator;
    public List<GameObject> buttonList;
    [SerializeField] TextMeshProUGUI textMesh;
    bool hasTypedAllText = true;

    int index;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (!hasTypedAllText)
            {
                InstantlyTypeRemainingText();
            }
            else if (index != text.Count - 1)
            {
                NextLine();
            }
            else if (!endsWithButton && !endsWithFight)
            {
                gameObject.SetActive(false);
            }
            else if (endsWithFight)
            {
                fightInitiator.StartBattle();
            }
        }
    }

    public void StartDialogue(DialogueInitiator converser)
    {
        dialogueInitiator = converser;
        hasTypedAllText = false;
        index = 0;
        textMesh.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() 
    {
        foreach (char character in text[index].ToCharArray())
        {
            //Debug.Log(index + " indecx" + hasTypedAllText);
            if (!hasTypedAllText)
            {

                textMesh.text += character;
                yield return new WaitForSeconds(textSpeeds[index]);
            }
            else
            {
                break;
            }
        }
        hasTypedAllText = true;
        if (endsWithButton && index == text.Count - 1)
        {
            revealButtons();
        }
    }

    void NextLine()
    {
        hasTypedAllText = false;
        index++;
        textMesh.text = string.Empty;
        StartCoroutine(TypeLine());
    }
    void InstantlyTypeRemainingText()
    {
        textMesh.text = text[index];
        hasTypedAllText = true;
        if (endsWithButton && index == text.Count - 1)
        {
            revealButtons();
        }
    }

    public void DialogueOption(int optionNumber)
    {
        foreach (GameObject button in buttonList)
        {
            button.SetActive(false);
        }
        textMesh.text = "";
        dialogueInitiator.StartConversation(nextPart[optionNumber]);
    }
    void revealButtons()
    {
        for (int i = 0; i < nextPart.Count; i++)
        {
            buttonList[i].SetActive(true);
            buttonList[i].GetComponentInChildren<TextMeshProUGUI>().text = dialogueOptionNames[i];
        }
    }
}
