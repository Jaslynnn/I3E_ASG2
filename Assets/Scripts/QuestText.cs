/**
Author: Jaslyn
Name of Class: QuestText
Description of Class: Quest UI and quests
Date Created:  17 july 21
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestText : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject QuestingText1;
    public GameObject QuestingText2;
    public GameObject QuestCountText;

    public int QuestCount;
    public string Status1;
    public string Status2;
    public string Status3;
    public string Status4;
    public string Status5;


    //Bools to indicate levels
    public bool Level1;
    public bool Level2;
    public bool Level3;

    void Start()
    {
        Status1 = "Undone";
        Status2 = "Undone";
        Status3 = "Undone";
        Status4 = "Undone";
        Status5 = "Undone";

        FirstLevel();
    }

    // Update is called once per frame
    void Update()
    {
        //level 1 quest
        if (Level1 == true)
        {
            FindPortalQuest1();
            ShootSlimeQuest();

        }
        //Level 2 Quest
        if (Level2 == true)
        {
            RetrieveIncubator();
            ShootBatQuest();
        }
        //Level 3 Quest
        if (Level3 == true)
        {
            GetHeartQuest();
        }

        ChangeQuestingCount();
    }

    //Activates the level
    public void FirstLevel()
    {
        Level1 = true;
        Level2 = false;
        Level3 = false;
    }

    public void SecondLevel()
    {
        Level2 = true;
        Level1 = false;
        Level3 = false;
    }

    public void ThirdLevel()
    {
        Level3 = true;
        Level2 = false;
        Level1 = false;
    }


    public void done1()
    {
        Status1 = "done";
        QuestCount += 1;
    }
    public void done2()
    {
        Status2 = "done";
        QuestCount += 1;
    }
    public void done3()
    {
        Status3 = "done";
        QuestCount += 1;
    }
    public void done4()
    {
        Status4 = "done";
        QuestCount += 1;
    }
    public void done5()
    {
        Status5 = "done";
        QuestCount += 1;
    }


    //Level 1 quest
    public void ShootSlimeQuest()
    {
        QuestingText1.GetComponent<Text>().text = "Shoot down 1 Slime : " + Status1;

    }
    public void FindPortalQuest1()
    {
        QuestingText2.GetComponent<Text>().text = "Find a portal : " + Status2;
 

    }

    //Level 2 quest
    public void ShootBatQuest()
    {
        QuestingText1.GetComponent<Text>().text = "Shoot down 1 Bat : " + Status3;
      
    }
    public void RetrieveIncubator()
    {
        QuestingText2.GetComponent<Text>().text = "Find the incubator : " + Status4;

    }



    //Level 3 quest
    public void GetHeartQuest()
    {
        QuestingText1.GetComponent<Text>().text = "Get the Living Heart : " + Status5;

    }

    public void ChangeQuestingCount()
    {
         QuestCountText.GetComponent<Text>().text = "These are the number of quests done : " + QuestCount;

    }
}
