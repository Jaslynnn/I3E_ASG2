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
        if(other.tag == "Level1" )
        {
            TeleportToLevel1();
        }
        if (other.tag == "Level2")
        {
            TeleportToLevel2();
        }
        if (other.tag == "Level3")
        {
            TeleportToLevel3();
        }

    }

    //Functions that the buttons on the menu can activate when the player wants to change levels
    public void TeleportToLevel1()
    {
        thePlayer.transform.position = Level1.transform.position;
    }
    public void TeleportToLevel2()
    {
        thePlayer.transform.position = Level2.transform.position;
    }
    public void TeleportToLevel3()
    {
        thePlayer.transform.position = Level3.transform.position;
    }

}
