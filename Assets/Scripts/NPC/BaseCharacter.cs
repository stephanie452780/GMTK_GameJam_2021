using System;
using System.Collections.Generic;
using UnityEngine;

/*
 * Create an NPC
 * Properties
 * - Name
 * - Instrument
 * - Dialogue list
 */

public enum Instruments
{
    Trumpet,
    Piano,
    Bass,
    Drums,
    Guitar,
    Saxophone
}

[Serializable]
public class Dialogue
{
    public bool isQuestion;
    [TextArea]
    public string text;
}

public class BaseCharacter : MonoBehaviour
{
    [TextArea]
    public string name;
    public Instruments instrument;
    public List<Dialogue> dialogueList;
    public Font font;

    public string GetName()
    {
        return name;
    }

    public List<Dialogue> GetDialogue()
    {
        return dialogueList;
    }

    public Font GetFont()
    {
        return font;
    }
}
