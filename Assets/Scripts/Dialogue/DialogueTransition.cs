using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Scene 0 - Title
 * Scene 1 - God
 * Scene 2 - Davie
 * Scene 3 - Elliot
 * Scene 4 - Monty
 * Scene 5 - Blake
 * Scene 6 - Mingu
 * Scene 7 - Jazz Performance
 * Scene 8 - Main Game
 */

public class DialogueTransition : MonoBehaviour
{
    public List<GameObject> sceneList;
    public List<Camera> cameraList;
    
    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void SceneTransition(int sceneNum)
    {
        switch(sceneNum)
        {
            case 0:
                sceneList[0].SetActive(true);
                cameraList[0].enabled = true;
                for (int i = 0; i < sceneList.Count; i++)
                {
                    if (i != sceneNum)
                    {
                        sceneList[i].SetActive(false);
                        cameraList[i].enabled = false;
                    }
                }
                break;
            case 1:
                sceneList[1].SetActive(true);
                cameraList[1].enabled = true;
                for (int i = 0; i < sceneList.Count; i++)
                {
                    if (i != sceneNum)
                    {
                        sceneList[i].SetActive(false);
                        cameraList[i].enabled = false;
                    }
                }
                break;
            case 2:
                sceneList[2].SetActive(true);
                cameraList[2].enabled = true;
                for (int i = 0; i < sceneList.Count; i++)
                {
                    if (i != sceneNum)
                    {
                        sceneList[i].SetActive(false);
                        cameraList[i].enabled = false;
                    }
                }
                break;
            case 3:
                sceneList[3].SetActive(true);
                cameraList[3].enabled = true;
                for (int i = 0; i < sceneList.Count; i++)
                {
                    if (i != sceneNum)
                    {
                        sceneList[i].SetActive(false);
                        cameraList[i].enabled = false;
                    }
                }
                break;
            case 4:
                sceneList[4].SetActive(true);
                cameraList[4].enabled = true;
                for (int i = 0; i < sceneList.Count; i++)
                {
                    if (i != sceneNum)
                    {
                        sceneList[i].SetActive(false);
                        cameraList[i].enabled = false;
                    }
                }
                break;
            case 5:
                sceneList[5].SetActive(true);
                cameraList[5].enabled = true;
                for (int i = 0; i < sceneList.Count; i++)
                {
                    if (i != sceneNum)
                    {
                        sceneList[i].SetActive(false);
                        cameraList[i].enabled = false;
                    }
                }
                break;
            case 6:
                sceneList[6].SetActive(true);
                cameraList[6].enabled = true;
                for (int i = 0; i < sceneList.Count; i++)
                {
                    if (i != sceneNum)
                    {
                        sceneList[i].SetActive(false);
                        cameraList[i].enabled = false;
                    }
                }
                break;
            case 7:
                sceneList[7].SetActive(true);
                cameraList[7].enabled = true;
                for (int i = 0; i < sceneList.Count; i++)
                {
                    if (i != sceneNum)
                    {
                        sceneList[i].SetActive(false);
                        cameraList[i].enabled = false;
                    }
                }
                break;
            case 8:
                sceneList[8].SetActive(true);
                cameraList[8].enabled = true;
                for (int i = 0; i < sceneList.Count; i++)
                {
                    if (i != sceneNum)
                    {
                        sceneList[i].SetActive(false);
                        cameraList[i].enabled = false;
                    }
                }
                break;
        }
    }
}
