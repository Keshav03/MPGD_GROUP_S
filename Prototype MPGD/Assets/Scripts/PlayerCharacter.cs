using System;
using UnityEngine;

//A script used to define the behaviour of the controlled playable character.
public class PlayerCharacter : MonoBehaviour
{
    //Variables to be used.
    public int moveSpeed = 5;
    public int rotationSpeed = 2;
    public int jumpForce = 10;
    public int maxHealth = 100;
    public int health;
    public int maxShield = 100;
    public int shield;

    //Call upon the Game Controller instance to set the UI elements based on the interactions of the player with the environment (enemies and pickups).
    public GameController gameController;

    [SerializeField]
    private Animator animator;
    private Rigidbody rigidbody;
    public HealthBar healthBar;
    public ArmorBar armorBar;

    //Call upon the Gun object to allow the player's behaviour to affect the gun's behaviour.
    public Gun gun;


    //Used to initialise the variables of the player alongside the variables in the Game Controller pertaining to the player.

    public GameObject gameOverMenu ;
    public static bool GameIsPause = false;


    void Start()
    {
        health = maxHealth;
        shield = maxShield;
        healthBar.SetMaxHealth(maxHealth);
        armorBar.SetMaxArmor(maxShield);
        GameObject gameC = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameC.GetComponent<GameController>();
        rigidbody = GetComponent<Rigidbody>();
    }




    // Update is called once per frame
    void Update()
    {
        //Used to move the player vertically with the W or A buttons.
        if (Input.GetAxis("Vertical")!=0)
        {
            animator.SetBool("run", true);
            animator.SetFloat("runspeed", Input.GetAxis("Vertical"));
            transform.position += transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        }
        
        //Used to move the player horizontally with the A or D buttons.
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("run", true);
            animator.SetFloat("runspeed", Input.GetAxis("Vertical"));
            transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
        }

        //Used to set the animations for the soldier asset during movement.
        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            animator.SetBool("run", false);
        }

        //Used to call upon the Shoot function on a user mouse click input.
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

        //Used to call upon the Jump function on a user input of Space on the keyboard.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        //Used to call upon the Reload function of the Gun object on a user input of R on the keyboard.
        if (Input.GetKeyDown(KeyCode.R))
        {
            gun.Reload();
        }

    }

    //A function used to make the player jump.
    private void Jump()
    {
        if(rigidbody.velocity.y==0)
        rigidbody.AddForce(Vector3.up *jumpForce , ForceMode.Impulse);
        
    }

    //A function used to set the player's health, first at the beginning of the game and whenever they are damaged or healed.
    public void SetHealth(int value){
        health += value;
        if (health >=maxHealth){
            health = maxHealth;
        }
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            gameOver();
        }
    }

    //A function used to set the player's armour, first at the beginning of the game and whenever they are damaged or healed.
    public void SetArmor(int value){
        shield += value;
        if (shield >= maxShield){
            shield = maxShield;
        }
        armorBar.SetArmor(shield);
    }


    /*public void Damage(int value,int value2)
    {
        SetHealth(value);
        SetArmor(value);
    }*/

    //A function used to call upon the shoot behaviour of the Gun object. Also displays an animation showing the gun being shot.
    void Shoot()
    {
        gun.Shoot();
        animator.SetTrigger("shoot");
    }

    //A function used for the interactions of the player's colliders with the pickups and enemies.
    void  OnCollisionEnter(Collision collisionInfo){

        GameObject obj = collisionInfo.collider.gameObject;

        //If colliding with a Health pickup.
        if (collisionInfo.collider.tag == "HealthPickUp"){

            if (health < maxHealth){
                //Destroy(obj);
                obj.SetActive(false);
                SetHealth(25);
            }

        }

        //If colliding with an Armor pickup.
        if (collisionInfo.collider.tag == "ArmorPickup"){
            if (shield < maxShield){
                //Destroy(obj);
                obj.SetActive(false);
                SetArmor(25);
            }
        }

        //If colliding with a KeyItem pickup.
        if (collisionInfo.collider.tag == "KeyItem")
        {
            obj.SetActive(false);
            gameController.ItemCollected();
        }

    }

    //A function used to make the game reset if the player's Health reaches 0.
    public void gameOver()
    {
        gameOverMenu.SetActive(true);
        GameIsPause = true;
        Time.timeScale = 0f;
        gameController.reset(); 
    }



}
