using UnityEngine;

public class Target : MonoBehaviour
{
    public float health;
    public Animator animator;
    public void TakeDamage(float amount)
    {
        animator.SetBool("BatGotHit", true);
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("BatDead", true);
    }
}
