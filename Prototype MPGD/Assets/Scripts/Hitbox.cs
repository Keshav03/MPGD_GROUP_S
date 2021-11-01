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
    void OnTriggerEnter(Collider other)
    {
        //If colliding with a pickup object, deactivate it.
        if (other.gameObject.tag == "HealthPickUp")
        {
            other.gameObject.SetActive(false);
            player.Damage(-50, 0);

            //Update the game about this collection
        }
        if (other.gameObject.tag == "ArmorPickUp")
        {
            other.gameObject.SetActive(false);
            player.Damage(0, -50);
        }
        //if colliding with an enemy character, decrease health by a set amount.
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
            player.Damage(50, 50);

            //Update the game about this collection
        }
    }
}
