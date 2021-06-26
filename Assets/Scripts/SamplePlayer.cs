/******************************************************************************
Author: Elyas Chua-Aziz

Name of Class: DemoPlayer

Description of Class: This class will control the movement and actions of a 
                        player avatar based on user input.

Date Created: 09/06/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePlayer : MonoBehaviour
{
    /// <summary>
    /// The distance this player will travel per second.
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rotationSpeed;

    /// <summary>
    /// The camera attached to the player model.
    /// Should be dragged in from Inspector.
    /// </summary>
    public Camera playerCamera;

    private string currentState;

    private string nextState;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        nextState = "Idle";
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nextState != currentState)
        {
            SwitchState();
        }

        CheckRotation();
    }

    /// <summary>
    /// Sets the current state of the player
    /// and starts the correct coroutine.
    /// </summary>
    private void SwitchState()
    {
        StopCoroutine(currentState);

        currentState = nextState;
        StartCoroutine(currentState);
    }

    private IEnumerator Idle()
    {
        while(currentState == "Idle")
        {
            if((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
            {
                nextState = "Moving"; 
            }

            yield return null;
        }
    }

    private IEnumerator Moving()
    {
        while (currentState == "Moving")
        {
            if (!CheckMovement())
            {
                nextState = "Idle";
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                TakeDamage(10);
            }

            yield return null;
        }
        
    }


private void CheckRotation()
    {
       

        Vector3 cameraRotation = playerCamera.transform.rotation.eulerAngles;
        cameraRotation.x += -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        cameraRotation.y += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        Vector3 playerRotation = cameraRotation;

        if(playerRotation.x != 0)
        {
            playerRotation.x = 0;
        }

        playerRotation.y += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(playerRotation); 
        playerCamera.transform.rotation = Quaternion.Euler(cameraRotation);

    }

    /// <summary>
    /// Checks and handles movement of the player
    /// </summary>
    /// <returns>True if user input is detected and player is moved.</returns>
    private bool CheckMovement()
    {
       
        Vector3 newPos = transform.position;
        Vector3 xMovement = transform.right * Input.GetAxis("Horizontal");
        Vector3 zMovement = transform.forward * Input.GetAxis("Vertical");


        Vector3 movementVector = xMovement + zMovement;



        if (movementVector.sqrMagnitude != 0)
        {
            movementVector *= moveSpeed * Time.deltaTime;
            newPos += movementVector;
        

            transform.position = newPos;
         

            return false;
        }



        else
        {
            return true;
        }


    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
