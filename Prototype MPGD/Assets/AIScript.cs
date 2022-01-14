using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour
{
    public FPSPlayer fpsc;
    public float fov = 120f;
    public float viewDistance = 10f;
    public bool isAware = false;
    private NavMeshAgent agent;
    private Renderer renderer;
    public float wanderRadius;
    public Vector3 wanderPoint;
    public float wanderSpeed = 4f;
    public float chaseSpeed = 7f;
    public float health = 100f;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        renderer = GetComponent<Renderer>();
        wanderPoint = RandomWanderPoint();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            agent.speed = 0;
            animator.enabled = false;
            return;
        }
        if (isAware)
        {
            agent.SetDestination(fpsc.transform.position);
            animator.SetBool("Aware", true);
            
            agent.speed = chaseSpeed;
            //renderer.material.color = Color.red;
        }
        else
        {
            SearchForPlayer();
            //renderer.material.color = Color.blue;
            Wander();
            animator.SetBool("Aware", false);
            agent.speed = wanderSpeed;
        }

    }
    public void SearchForPlayer()
    {
        if (Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(fpsc.transform.position)) < fov / 2f)
        {
            if (Vector3.Distance(fpsc.transform.position, transform.position) < viewDistance)
            {
                RaycastHit hit;
                if (Physics.Linecast(transform.position, fpsc.transform.position, out hit, -1))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        OnAware();
                    }

                }

            }
        }
    }


    public void OnAware()
    {
        isAware = true;
    }

    public Vector3 RandomWanderPoint()
    {
        Vector3 randomPoint = (Random.insideUnitSphere * wanderRadius) + transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomPoint, out navHit, wanderRadius, -1);
        return new Vector3(navHit.position.x, transform.position.y, navHit.position.z);
    }
    public void Wander()
    {
        if (Vector3.Distance(transform.position, wanderPoint) < 2f)
        {
            wanderPoint = RandomWanderPoint();
        }
        else
        {
            agent.SetDestination(wanderPoint);
        }

    }
    public void OnHit(float damage)
    {
        health -= damage;
    }

}
