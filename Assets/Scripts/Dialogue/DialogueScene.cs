using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Dialogue Scene Setup
 * Text
 * Change NPC
 */

public class DialogueScene : MonoBehaviour
{
    public Text characterText;
    public Text dialogueText;
    public GameObject player;
    public GameObject npc;
    public bool playerTalkFirst;

    private List<string> playerText;
    private Font playerFont;
    private string npcName;
    private List<string> npcText;
    private Font npcFont;
    private bool continueConvo;

    private int playerIndex;
    private int npcIndex;
    private bool playerLastTalk;
    private int index;
    
    // Start is called before the first frame update
    void Start()
    {
        playerText = player.GetComponent<BaseNPC>().GetDialogue();
        playerFont = player.GetComponent<BaseNPC>().GetFont();
        npcName = npc.GetComponent<BaseNPC>().GetName();
        npcText = npc.GetComponent<BaseNPC>().GetDialogue();
        npcFont = npc.GetComponent<BaseNPC>().GetFont();
        continueConvo = false;
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
            print("player index: " + playerIndex);
            print("npc index: " + npcIndex);
            if (!playerLastTalk && playerIndex < playerText.Count)
            {
                CharactersTalk("player", playerText[playerIndex], playerFont);
                playerIndex++;
                print("player index: " + playerIndex);
                playerLastTalk = true;
            }
            else if (playerLastTalk && npcIndex < npcText.Count)
            {
                CharactersTalk(npcName, npcText[npcIndex], npcFont);
                npcIndex++;
                print("npc index: " + npcIndex);
                playerLastTalk = false;
            }
        }
            
    }
    

    void CharactersTalk(string characterName, string dialogue, Font textFont)
    {
        //if (!String.IsNullOrEmpty(dialogue))
        
            characterText.text = characterName;
        characterText.font = textFont;
        print("character name: " + characterName);
            dialogueText.text = dialogue;
        dialogueText.font = textFont;
        
        
        print("inside charactertalk");
        
    }

    IEnumerator ContinueTalk()
    {
        //bool wait = true;
        //while (wait)
        //{
        //    if (Input.anyKeyDown)
        //    {
        //        wait = false;
        //    }
        //    print(wait);
        //    yield return new WaitForSeconds(3.0f);
        //}
        //yield return new WaitForSeconds(3.0f);
        yield return new WaitForSeconds(5.0f);
    }
}
