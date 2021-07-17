using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestText : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject QuestingText1;
    public GameObject QuestingText2;
    public GameObject QuestingText3;
    public GameObject QuestCountText;

    public int QuestCount;
    public string Status1;
    public string Status2;
    public string Status3;
    public string Status4;
    public string Status5;
    public string Status6;

    //Bools to indicate levels
    public bool Level1;
    public bool Level2;
    public bool Level3;

    void Start()
    {
        Status1 = "Undone";
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
            FindPortalQuest2();
        }
        //Level 3 Quest
        if (Level3 == true)
        {
            KillBossQuest();
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

    public void done3()
    {
        Status3 = "done";
    }
    public void done1()
    {
        Status1 = "done";
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

    public void FindPortalQuest2()
    {
        QuestingText3.GetComponent<Text>().text = "Find a portal : " + Status5;


    }

    //Level 3 quest
    public void KillBossQuest()
    {
        QuestingText1.GetComponent<Text>().text = "Kill the boss : " + Status6;

    }
    public void ChangeQuestingCount()
    {
         QuestCountText.GetComponent<Text>().text = "These are your current number of quests : " + QuestCount;

    }
}
