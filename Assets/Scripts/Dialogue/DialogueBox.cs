using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueBox : MonoBehaviour
{
    public List<string> text;
    public List<float> textSpeeds;
    [SerializeField] TextMeshProUGUI textMesh;
    bool hasTypedAllText = true;

    int index;

    private void OnEnable()
    {
        StartDialogue();
    }

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
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    void StartDialogue()
    {
        hasTypedAllText = false;
        index = 0;
        textMesh.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() 
    {
        foreach (char character in text[index].ToCharArray())
        {
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
    }
}
