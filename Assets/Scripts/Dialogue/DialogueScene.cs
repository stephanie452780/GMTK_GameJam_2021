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

    private List<Dialogue> playerText;
    private Font playerFont;
    private string npcName;
    private List<Dialogue> npcText;
    private Font npcFont;

    private int playerIndex;
    private int npcIndex;
    private bool playerLastTalk;
    
    // Start is called before the first frame update
    void Start()
    {
        playerText = player.GetComponent<Player>().GetDialogue();
        playerFont = player.GetComponent<Player>().GetFont();
        npcName = npc.GetComponent<BaseCharacter>().GetName();
        npcText = npc.GetComponent<BaseCharacter>().GetDialogue();
        npcFont = npc.GetComponent<BaseCharacter>().GetFont();
        playerIndex = 0;
        npcIndex = 0;

        if (playerTalkFirst)
        {
            CharactersTalk("player", playerText[playerIndex], playerFont);
            playerLastTalk = true;
            playerIndex++;
        }
        else
        {
            CharactersTalk(npcName, npcText[npcIndex], npcFont);
            playerLastTalk = false;
            npcIndex++;
        }
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (!playerLastTalk && playerIndex < playerText.Count)
            {
                CharactersTalk("player", playerText[playerIndex], playerFont);
                playerIndex++;
                playerLastTalk = true;
            }
            else if (playerLastTalk && npcIndex < npcText.Count)
            {
                CharactersTalk(npcName, npcText[npcIndex], npcFont);
                npcIndex++;
                playerLastTalk = false;
            }
        }    
    }
    
    void CharactersTalk(string characterName, Dialogue dialogue, Font textFont)
    {
        characterText.text = characterName;
        characterText.font = textFont;
        for (int i = 0; i < dialogue.text.Count; i++)
        {
            dialogueText.text = dialogue.text[i];
        }
        dialogueText.font = textFont;
        if (dialogue.isQuestion)
        {
            PlayerReply();
        }
    }

    void PlayerReply()
    {

    }
}
