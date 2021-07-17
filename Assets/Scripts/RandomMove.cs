/**
Author: Kirdesh
Name of Class: RandomMove
Description of Class: Allow the enemy to move randomly
Date Created: 17 july 21
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMove : MonoBehaviour
{
    NavMeshAgent navMeshAgent;

    public float timeForNewPath;

    bool inCoRoutine;
    bool RandomMovement;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        RandomMovement = true;
    }


    // Update is called once per frame
    void Update()
    {
        if(RandomMovement == true)
        {
            if (!inCoRoutine)
            StartCoroutine(DoSomething());

        }


    }

    Vector3 getNewRandomPosition()
    {

        float x = Random.Range(-20, 20);
        float z = Random.Range(-20, 20);

        Vector3 pos = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        return pos;
    }

    IEnumerator DoSomething()
    {
        inCoRoutine = true;
        yield return new WaitForSeconds(timeForNewPath);
        GetNewPath();
        inCoRoutine = false;
    }

    void GetNewPath()
    {
        navMeshAgent.SetDestination(getNewRandomPosition());
    }


    public void StopRandomMovement()
    {
        RandomMovement = false;
    }

}

