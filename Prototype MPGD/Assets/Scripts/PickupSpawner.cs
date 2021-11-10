using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject parent;
    public Enemy enemy;
    public int numberToSpawn;
    public int limit = 6;
    public float rate;
    public GameObject gameO;
    

    float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = rate;
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.transform.childCount <= limit)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                for (int i = 0; i < numberToSpawn; i++)
                {
                    Instantiate(objectToSpawn, new Vector3(parent.transform.position.x + GetModifier(), parent.transform.position.y, (parent.transform.position.z + GetModifier())/5), Quaternion.identity, parent.transform);
                    objectToSpawn.SetActive(true);
                    if (objectToSpawn.tag == "Enemy")
                    {
                        GameObject gameO = GameObject.FindGameObjectWithTag("Enemy");
                        enemy = gameO.GetComponent<Enemy>();
                       
                        enemy.SetHealth(100);
                    }
                }
                spawnTimer = rate;
               
            }
        }
    }

    float GetModifier()
    {
        float modifier = Random.Range(0f, 5f);
        if (Random.Range(0, 5) > 0)
            return -modifier;
        else
            return modifier;
    }


}

