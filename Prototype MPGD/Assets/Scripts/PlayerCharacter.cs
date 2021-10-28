using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public int moveSpeed = 5;
    public int rotationSpeed = 2;
    public int health = 100;

    [SerializeField]
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical")!=0)
        {
            animator.SetBool("run", true);
            animator.SetFloat("runspeed", Input.GetAxis("Vertical"));
            transform.position += transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("run", true);
            animator.SetFloat("runspeed", Input.GetAxis("Vertical"));
            transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);

        }

        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            animator.SetBool("run", false);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    void Damage(int value)
    {
        health -= value;

    }
    void Shoot()
    {
        animator.SetTrigger("shoot");

    }
}
