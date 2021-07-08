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
using UnityEngine.UI;
using UnityEngine.AI;



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

    public bool StartingGame;
    public bool GameStarted;

    // When Player walks into trigger, the enemy will chase it
    public BatSettings batSettings;
    public Transform Player;
    public NavMeshAgent enemy;
    public bool BatAttack;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        nextState = "Idle";
        StartingGame = false;
        GameStarted = false;


}

    // Update is called once per frame
    void Update()
    {
        if (StartingGame == true)
        {
            GameStarted = true;
            StartGame();

        }

        if (GameStarted == false) 
        {
            StartingGame = false;
        }
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

            yield return null;
        }
        
    }

    public void StartGame()
    {
        if (nextState != currentState)
        {
            SwitchState();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }

        CheckRotation();
    }

    public void PauseGame()
    {
        Debug.Log("The game has been paused");
    }

    //Create bool that allows the game to start by activating the start game
    public void TapToStart()
    {
        StartingGame = true;
    }

    //Create bool that allows the game to pause when the menu button is clicked
    public void TapToPause()
    {
        StartingGame = false;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyZone")
        {
            batSettings.BatAttack();

        }


    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "EnemyZone")
        {
            enemy.SetDestination(Player.position);
            batSettings.BatFlying();


        }


        if (other.tag == "Enemy")
        {
            enemy.isStopped = true;
            TakeDamage(1);
        }
    }




}
