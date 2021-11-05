using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public PlayerCharacter player;
 
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameO = GameObject.FindGameObjectWithTag("Player");
        player = gameO.GetComponent<PlayerCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        //if colliding with an enemy character, decrease health by a set amount.
        if (other.gameObject.tag == "Enemy")
        {
            //other.gameObject.SetActive(false);
            if (player.shield > 0) {
                player.SetArmor(-50);
            }
            else
            {
                player.SetHealth(-50);
            }
                    

            //Update the game about this collection
        }
    }
}
