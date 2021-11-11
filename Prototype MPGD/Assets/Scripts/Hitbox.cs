using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//A class used for the hitbox used for the player's interactions with the enemy.
public class Hitbox : MonoBehaviour
{
    //Variables to be used.
    public PlayerCharacter player;
 
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameO = GameObject.FindGameObjectWithTag("Player"); //Make a GameObject for the player/
        player = gameO.GetComponent<PlayerCharacter>(); //Set GameObject of player to the type player.
    }

    //Function used for collisions between the hitbox and objects of type Enemy.
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //If colliding with an enemy character, decrease Armour by a set amount if Armour is still available on player.
            if (player.shield > 0) {
                player.SetArmor(-50);
            }
            
            //Decrease Health by a set amount if there is no Armour available.
            else
            {
                player.SetHealth(-50);
            }
        }
    }
}
