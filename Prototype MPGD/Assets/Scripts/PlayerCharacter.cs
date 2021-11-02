using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public int moveSpeed = 5;
    public int rotationSpeed = 2;
    public int maxHealth = 100;
    public int health;
    public int maxShield = 100;
    public int shield;
   

    [SerializeField]
    private Animator animator;

    public HealthBar healthBar;
    public ArmorBar armorBar;
    

    public Gun gun;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        shield = maxShield;
        healthBar.SetMaxHealth(maxHealth);
        armorBar.SetMaxArmor(maxShield);
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

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            gun.Reload();
        }

    }


    public void SetHealth(int value){
        health += value;
        if (health >=maxHealth){
            health = maxHealth;
        }
        healthBar.SetHealth(health);
    }

    public void SetArmor(int value){
        shield += value;
        if (shield >= maxShield){
            shield = maxShield;
        }
        armorBar.SetArmor(shield);
    }


    public void Damage(int value,int value2)
    {
        SetHealth(value);
        SetArmor(value);
    }

    void Shoot()
    {
        gun.Shoot();
        animator.SetTrigger("shoot");
    }

    void  OnCollisionEnter(Collision collisionInfo){

        GameObject obj = collisionInfo.collider.gameObject;
        if (collisionInfo.collider.tag == "HealthPickUp"){

            if (health < maxHealth){
                //Destroy(obj);
                obj.SetActive(false);
                SetHealth(25);
            }

        }

        if (collisionInfo.collider.tag == "ArmorPickup"){
            if (shield < maxShield){
                //Destroy(obj);
                obj.SetActive(false);
                SetArmor(25);
            }
        }

        if (collisionInfo.collider.tag == "Enemy"){
            //Destroy(obj);
            
            Damage(-25,-25);
        }

    }



}
