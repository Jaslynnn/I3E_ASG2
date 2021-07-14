using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public Animator animator;
    public NavMeshAgent enemy;
    public QuestText QuestStatus;
    public int BatDeathCount;
    public GameObject BatStatus;
    public void TakeDamage(float amount)
    {
        animator.SetBool("BatGotHit", true);
        Debug.Log("I have been hit");
        health -= amount;
        animator.SetBool("BatGotHit", false);
        if (health <= 0f)
        {
            Die();
            BatStatus.SetActive(false);
        }
    }

    public void Update()
    {
        ChangeBatStatusText();
    }
    void Die()
    {
        animator.SetBool("BatDead", true);
        enemy.isStopped = true;
        BatDeathCount += 1;
        QuestStatus.done();
        Debug.Log("I am dead");


    }
    public void ChangeBatStatusText()
    {
        BatStatus.GetComponent<TextMesh>().text = "Health : " + health;

    }
}
