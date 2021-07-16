using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class Target : MonoBehaviour
{
    public float health;
    public Animator animator;
    public NavMeshAgent enemy;
    public QuestText QuestStatus;
    public int BatDeathCount;
    public GameObject BatStatus;
    public void TakeDamage(float amount)
    {
        animator.SetBool("BatGotHit", true);
        ///deduct health
        health -= amount;
        animator.SetBool("BatGotHit", false);
        if (health <= 0f)
        {
            Die();
            BatStatus.SetActive(false);
        }
    }

    public void Update()
    {/// Notify the player that the Bats health is decreasing so that they know that they have to keep on shooting
        ChangeBatStatusText();
    }
    void Die()
    {
        animator.SetBool("BatDead", true);
        enemy.isStopped = true;
        BatDeathCount += 1;
        ///Activate the Quest to change words
        QuestStatus.done();
        Debug.Log("I am dead");
        /// Change Enemy tag so that the health of the player does not decrease when the player goes over the dead body of the enemy.
        enemy.tag = "DeadEnemy";


    }
    public void ChangeBatStatusText()
    {
        BatStatus.GetComponent<TextMesh>().text = "Health : " + health;

    }
}
