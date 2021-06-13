using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Dialogue Scene Setup
 * Text
 * Change Character
 */

public class DialogueScene : MonoBehaviour
{
    public Text characterText;
    public Text dialogueText;
    public GameObject player;
    public GameObject npc;
    public bool playerTalkFirst;

    public Canvas replyUI;
    public Text yesText;
    public Text noText;
    public int noLineNum;

    private string playerName;
    private List<Dialogue> playerText;
    private Font playerFont;
    private string npcName;
    private List<Dialogue> npcText;
    private Font npcFont;

    private int playerIndex;
    private int npcIndex;
    private int multiLine;
    private bool playerLastTalk;
    private bool waitingResponse;
    private bool startedRoutine;
    private bool stopTalk;
    
    // Start is called before the first frame update
    void Start()
    {
        if (playerTalkFirst)
        {
            replyUI.enabled = false;
        }
        playerName = player.GetComponent<BaseCharacter>().GetName();
        playerText = player.GetComponent<BaseCharacter>().GetDialogue();
        playerFont = player.GetComponent<BaseCharacter>().GetFont();
        npcName = npc.GetComponent<BaseNPC>().GetName();
        npcText = npc.GetComponent<BaseNPC>().GetDialogue();
        npcFont = npc.GetComponent<BaseNPC>().GetFont();
        playerIndex = 0;
        npcIndex = 0;
        multiLine = 1;
        waitingResponse = false;
        startedRoutine = false;
        stopTalk = false;

        if (playerTalkFirst)
        {
            CharactersTalk(playerName, playerText[playerIndex], multiLine - 1, playerFont);
            if (multiLine == playerText[playerIndex].text.Count)
            {
                playerLastTalk = true;
                playerIndex++;
            }
            else
            {
                multiLine++;
            }
            print("player talk");
            //playerIndex++;
        }
        else
        {
            CharactersTalk(npcName, npcText[npcIndex], multiLine - 1, npcFont);
            if (multiLine == playerText[playerIndex].text.Count)
            {
                playerLastTalk = false;
                npcIndex++;
            }
            else
            {
                multiLine++;
            }
            print("npc talk");
            //npcIndex++;
        }
    }

    void Update()
    {
        if (!stopTalk && !waitingResponse && (Input.GetKeyDown(KeyCode.E) ) )//|| Input.GetMouseButtonDown(0)))
        {
            if (!playerLastTalk && playerIndex < playerText.Count)
            {
                if (multiLine < playerText[playerIndex].text.Count)
                {
                    CharactersTalk(playerName, playerText[playerIndex], multiLine - 1, playerFont);
                    multiLine++;
                }
                else
                {
                    CharactersTalk(playerName, playerText[playerIndex], multiLine - 1, playerFont);
                    playerIndex++;
                    playerLastTalk = true;
                    multiLine = 1;
                }
            }
            else if (playerLastTalk && npcIndex < npcText.Count)
            {
                if (multiLine < npcText[npcIndex].text.Count)
                {
                    CharactersTalk(npcName, npcText[npcIndex], multiLine - 1, npcFont);
                    multiLine++;
                }
                else
                {
                    CharactersTalk(npcName, npcText[npcIndex], multiLine - 1, npcFont);
                    npcIndex++;
                    playerLastTalk = false;
                    multiLine = 1;
                }
            }
        }    
        if (waitingResponse && !startedRoutine)
        {
            StartCoroutine(PlayerResponse());
            print("waiting");
            startedRoutine = true;
        }
    }
    
    void CharactersTalk(string characterName, Dialogue dialogue, int lineNum, Font textFont)
    {
        if (dialogue.isQuestion && characterName == playerName)
        {
            stopTalk = true;
            print("stop talk");
            return;
        }
        characterText.text = characterName;
        characterText.font = textFont;
        dialogueText.text = dialogue.text[lineNum];
        dialogueText.font = textFont;
        print("dialogue count: " + dialogue.text.Count);
        print("line num: " + lineNum);
        if (dialogue.isQuestion && characterName == npcName && lineNum == dialogue.text.Count - 1)
        {
            waitingResponse = true;
            yesText.text = playerText[playerIndex].text[0];
            yesText.font = playerFont;
            noText.text = playerText[noLineNum].text[0];
            noText.font = playerFont;
        }
    }

    IEnumerator PlayerResponse()
    {
        replyUI.enabled = true;

        while (waitingResponse)
        {
            yield return null;
        }
    }

    public void ReplyYes()
    {
        CharactersTalk(playerName, playerText[playerIndex], 0, playerFont);
        playerIndex++;
        playerLastTalk = true;
        waitingResponse = false;
        replyUI.enabled = false;
        print("yes");
    }

    //lineIndex = starting line to continue player and npc dialogue
    public void ReplyNo(string playerNPCLineIndex)
    {
        playerIndex = int.Parse(playerNPCLineIndex.Substring(0,1));
        npcIndex = int.Parse(playerNPCLineIndex.Substring(1,1));
        print("player index: " + playerIndex);

        characterText.text = playerName;
        characterText.font = playerFont;
        dialogueText.text = playerText[playerIndex].text[0];
        dialogueText.font = playerFont;

        playerIndex++;
        playerLastTalk = true;
        waitingResponse = false;
        replyUI.enabled = false;
        print("no");
    }
}
