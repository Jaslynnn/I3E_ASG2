/**
Author:  Jaslyn
Name of Class: Teleportation
Description of Class: Teleport the player from one scene to another
Date Created:  16 july 21
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public Transform Level1;
    public Transform Level2;
    public Transform Level3;
    public GameObject thePlayer;
    public QuestText ChangeQuestText;

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Level2")
        {
            TeleportToLevel2();
            ChangeQuestText.done2();
        }
        if (other.tag == "Level3")
        {
            TeleportToLevel3();
    
        }

    }

    //Functions that the buttons on the menu can activate when the player wants to change levels
    public void TeleportToLevel1()
    {
        ChangeQuestText.FirstLevel();
        thePlayer.transform.position = Level1.transform.position;
        

    }
    public void TeleportToLevel2()
    {
        ChangeQuestText.SecondLevel();

        thePlayer.transform.position = Level2.transform.position;
    }
    public void TeleportToLevel3()
    {
        ChangeQuestText.ThirdLevel();
        thePlayer.transform.position = Level3.transform.position;
    }

}
