using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSettings : MonoBehaviour
{
    public Animator animator;
    public int HitCount;
    public bool Hit;
    // Start is called before the first frame update
    void Start()
    {
        Hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Hit == true)
        {
            animator.SetBool("BatHit", true );
        }

        if (Hit == false)
        {
            animator.SetBool("BatHit", true);
        }

        animator.SetInteger("HitCount", HitCount);
    }

    //If player is hit, hit count go up and hit = true
}
