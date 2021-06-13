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
    Guitar
}

public class BaseNPC:MonoBehaviour
{
    [TextArea]
    public string name;
    public Instruments instrument;
    public List<string> dialogue;
    public Font font;
    private bool bandMember = false;

    public string GetName()
    {
        return name;
    }

    public List<string> GetDialogue()
    {
        return dialogue;
    }

    public Font GetFont()
    {
        return font;
    }

    public bool GetMember()
    {
        return bandMember;
    }
}
