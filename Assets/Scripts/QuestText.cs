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
    void Start()
    {
        Status = "Undone";
    }

    // Update is called once per frame
    void Update()
    {
        ChangeQuestingText1();
        ChangeQuestingText2();
        ChangeQuestingText3();
        ChangeQuestingCount();
    }

    public void done()
    {
        Status = "done";
    }
    public void ChangeQuestingText1()
    {
        QuestingText1.GetComponent<Text>().text = "Shoot down 1 bat : " + Status;
      
    }
    public void ChangeQuestingText2()
    {
        QuestingText2.GetComponent<Text>().text = "Find a gun : " + Status;

    }
    public void ChangeQuestingText3()
    {
        QuestingText3.GetComponent<Text>().text = "Find a portal : " + Status;
 

    }
    public void ChangeQuestingCount()
    {
         QuestCountText.GetComponent<Text>().text = "These are your current number of quests : " + QuestCount;

    }
}
