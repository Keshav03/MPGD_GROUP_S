using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script used for Enemy behaviour.
public class Enemy : MonoBehaviour
{

    //Variables that will be used by this class
    public Transform target;
    public float speed = 4f;
    Rigidbody rig;
    public float health = 100;
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>(); //Get rigidbody collider of enemy to be used for enemy and player interactions.
        GameObject gameC = GameObject.FindGameObjectWithTag("GameController"); //Call the game controller to alter the game itself duringg enemy and player interactions.
        gameController = gameC.GetComponent<GameController>(); //Set gameController to type GameController.
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime); //Get position of the player character.
        rig.MovePosition(pos); //Move rigidbody collider towards the position of the player character.
        transform.LookAt(target); //Change the direction of the collider towards the direction of the player character.
    }
    
    //A function used to make the enemy take damage and make them disappear if total damage taken >= their health.
    public void takeDamage(int damage)
    {
        health -= damage;
        if (health == 00)
        {
            gameController.EnemyKilled();
            gameObject.SetActive(false);
        }
    }

    //Used to set the initial health of enemy character instances.
    public void SetHealth(int hp)
    {
        health = hp;
    }
}