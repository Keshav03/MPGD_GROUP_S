using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //Variables that will be used by this class
    public Transform target;
    public float speed = 4f;
    Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
        rig.MovePosition(pos);
        transform.LookAt(target);
    }
}