using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialoguePart
{
    public List<string> lines;
    public List<float> lineSpeeds;
    public bool endsWithChoice = false;
    public List<int> nextPart;
    public List<string> dialogueOptionName;
    public bool endsWithFight = false;
    [ConditionalHide("endsWithFight", true)] public FightInitiator fightInitiator;
}
