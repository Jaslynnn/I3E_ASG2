using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class Target : MonoBehaviour
{
    public float Bathealth;

    public float Slimehealth;
    public Animator animator;
    public Animator animator2; 

    public NavMeshAgent enemy;
    public NavMeshAgent slime;

    public QuestText QuestStatus;

    public int BatDeathCount;
    public GameObject BatStatus;
    public GameObject SlimeStatus;
    public GameObject RealHeart;

    public void BatTakeDamage(float amount)
    {
        animator.SetBool("BatGotHit", true);
        ///deduct health
        Bathealth -= amount;
        animator.SetBool("BatGotHit", false);
        if (Bathealth <= 0f)
        {
            BatDie();
            ///Make the Status bar of the bat dissapear because it looks weird if left on the screen
            BatStatus.SetActive(false);
        }
    }
    public void SlimeTakeDamage(float amount)
    {
        
        ///deduct health
        Slimehealth -= amount;
        
        if (Slimehealth <= 0f)
        {
            SlimeDie();
            ///Make the Status bar of the bat dissapear because it looks weird if left on the screen
            SlimeStatus.SetActive(false);
        }
    }

    public void Update()
    {/// Notify the player that the Bats health is decreasing so that they know that they have to keep on shooting
        ChangeBatStatusText();
        ChangeSlimeStatusText();
    }
    void BatDie()
    {
        animator.SetBool("BatDead", true);
        enemy.isStopped = true;
        BatDeathCount += 1;
        ///Activate the Quest to change words
        QuestStatus.done3();
        Debug.Log("I am dead");
        /// Change Enemy tag so that the health of the player does not decrease when the player goes over the dead body of the enemy.
        enemy.tag = "DeadEnemy";

        RealHeart.SetActive(true);

    }
    void SlimeDie()
    {
        animator2.SetBool("SlimeGotHit", true);
        slime.isStopped = true;
       
        ///Activate the Quest to change words
        QuestStatus.done1();
        Debug.Log("I am dead");
        /// Change Enemy tag so that the health of the player does not decrease when the player goes over the dead body of the enemy.
        enemy.tag = "DeadEnemy";

        RealHeart.SetActive(true);

    }
    /// <summary>
    /// Changes the Status of the Bat health when it is shot 
    /// </summary>
    public void ChangeBatStatusText()
    {
        BatStatus.GetComponent<TextMesh>().text = "Health : " + Bathealth;

    }
    public void ChangeSlimeStatusText()
    {
        SlimeStatus.GetComponent<TextMesh>().text = "Health : " + Slimehealth;

    }
}
