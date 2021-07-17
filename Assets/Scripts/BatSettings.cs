using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSettings : MonoBehaviour
{
    public Animator animator;
    public int HitCount;
    public bool Hit;


    public void BatAttack()
    {
        animator.SetTrigger("BatAttacking");
        
    }
    public void BatFlying()
    {
        animator.SetBool("BatReturn",true);

    }


    //If player is hit, hit count go up and hit = true
}
