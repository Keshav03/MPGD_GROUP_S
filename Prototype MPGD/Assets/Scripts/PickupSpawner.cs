using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A script used for the random spawner of enemies and pickups for the game.
public class PickupSpawner : MonoBehaviour
{
    //Variables to be used.
    public GameObject objectToSpawn; //Instances of the cloned objects.
    public GameObject parent; //Parent object.
    public Enemy enemy; //Used for a conditional if an enemy object is spawned.
    public int numberToSpawn; //Used to determine the number of objects spawned.
    public int limit = 6; //Limiter used to check if max objects have been spawned.
    public float rate; //The rate at which objects will be spawned.
    public GameObject gameO; //Used for instantiation of game objects.
    public float spawnTimer; //Used to set the time frame between each instantiation of a spawned object.

    //Used to set the timer to maximum for the spawns.
    void Start()
    {
        spawnTimer = rate;
    }

    void Update()
    {
        //If the number of objects that have been spawned has not exceeded the limit.
        if (parent.transform.childCount <= limit)
        {
            spawnTimer -= Time.deltaTime; //Decrease the time between each instanced spawn.
            if (spawnTimer <= 0f) //If is time to spawn.
            {
                for (int i = 0; i < numberToSpawn; i++)
                {
                    //Used to creata new instance of an object that is a clone of a set parent object that will be spawned in a random position relative to the parent.
                    Instantiate(objectToSpawn, new Vector3(parent.transform.position.x + GetModifier(), parent.transform.position.y, (parent.transform.position.z + GetModifier())/5), Quaternion.identity, parent.transform);

                    //Used to make the cloned objects active if parent is already inactive.
                    objectToSpawn.SetActive(true);

                    //If the spawned enemy is object, make sure that they all have full HP when spawned.
                    if (objectToSpawn.tag == "Enemy")
                    {
                        GameObject gameO = GameObject.FindGameObjectWithTag("Enemy");
                        enemy = gameO.GetComponent<Enemy>();
                        enemy.SetHealth(100);
                    }
                }
                spawnTimer = rate; //Used to reset the spawn timer.
            }
        }
    }

    //A function used for the randomisation of the spawned objects.
    float GetModifier()
    {
        //Set the values between a range of -5 <= value <= 5.
        float modifier = Random.Range(0f, 5f);
        if (Random.Range(0, 5) > 0)
            return -modifier;
        else
            return modifier;
    }


}

