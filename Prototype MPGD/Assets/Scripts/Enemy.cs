using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        rig = GetComponent<Rigidbody>();
        GameObject gameC = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameC.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
        rig.MovePosition(pos);
        transform.LookAt(target);
    }
    public void takeDamage(int damage)
    {
        health -= damage;
        if (health == 00)
        {
            gameController.EnemyKilled();
            gameObject.SetActive(false);
        }
    }
    public void SetHealth(int hp)
    {
        health = hp;
    }
}