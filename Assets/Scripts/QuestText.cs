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
    public string Status;

    //Bools to indicate levels
    public bool Level1;
    public bool Level2;
    public bool Level3;

    void Start()
    {
        Status = "Undone";
        Level1 = true;
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

    public void done()
    {
        Status = "done";
    }

    //Level 1 quest
    public void FindPortalQuest1()
    {
        QuestingText3.GetComponent<Text>().text = "Find a portal : " + Status;
 

    }
    public void ShootSlimeQuest()
    {
        QuestingText1.GetComponent<Text>().text = "Shoot down 1 bat : " + Status;

    }

    //Level 2 quest
    public void ShootBatQuest()
    {
        QuestingText1.GetComponent<Text>().text = "Shoot down 1 slime : " + Status;
      
    }
    public void RetrieveIncubator()
    {
        QuestingText2.GetComponent<Text>().text = "Find the incubator : " + Status;

    }

    public void FindPortalQuest2()
    {
        QuestingText3.GetComponent<Text>().text = "Find a portal : " + Status;


    }

    //Level 3 quest
    public void KillBossQuest()
    {
        QuestingText1.GetComponent<Text>().text = "Kill the boss : " + Status;

    }
    public void ChangeQuestingCount()
    {
         QuestCountText.GetComponent<Text>().text = "These are your current number of quests : " + QuestCount;

    }
}
