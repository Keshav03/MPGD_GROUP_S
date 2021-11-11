using UnityEngine;
using UnityEngine.UI;

//Script used to define Gun behaviour.
public class Gun : MonoBehaviour
{
    //Variables to be used.
    public string gunName;
    public int damage;
    public int range;
    public float fireRate;
    private float nextFire;
    //public int accuracy;

    //Variables pertaining to the gun's ammunition.
    public int round;
    public int magazineSize;
    public int currentAmmo;
    public bool reloading = false;

    //Used to define from where the gun's projectiles come from.
    public Camera playerCam;

    //Used to change the UI displaying the gun's properties such as the name and ammunition left.
    public ChangeText ammoText;
    public ChangeText roundAmmoText;
    public ChangeText gunText;

    //Used to construct objects of type Gun.
    public Gun(string name1, int damage1, int range1, float fireRate1, int round1, int magazineSize1)
    {
        gunName = name1;
        damage = damage1;
        range = range1;
        fireRate = fireRate1;
        round = round1;
        magazineSize = magazineSize1;
        currentAmmo = magazineSize;
    }

    //Used to initialise the UI with the starting gun's name, current and left over ammunition.
    public void Start()
    {
        ammoText.setText(magazineSize);
        roundAmmoText.setText(round);
        gunText.setText(gunName);
    }

 
    public void update()
    {
        //If mouse click is down by the user, attempts to shoot a projectile and then stops the player from shooting another one for a set time period.
         if (Input.GetButtonDown("Fire1") && currentAmmo > 0 && Time.time > nextFire)
         {
             nextFire = Time.time + fireRate;
             Shoot();
         }

         //Used to set the reload state of the gun, which changes the current and left over ammunition by calling the Reload function.
         if (Input.GetKeyDown(KeyCode.R) && currentAmmo < magazineSize && !reloading)
         {
             reloading = true;
             Reload();
         }

    }

    //Function used to set the reload state of the gun.
    public void Reload()
    {
        //If no ammunition is left.
        if(round == 0 )
        {
            Debug.Log("No Round Left");
            return;
        }

        //If ammunition is left.
        else
        {
            if(currentAmmo == magazineSize)
            {
                Debug.Log("Ammo Full");
            }

            else
            {
                round = (currentAmmo + round) - magazineSize;

                //Used to go back to the first conditional if ammo left is 0 by the next reload.
                if(round <= 0)
                {
                    round = 0;
                }

                currentAmmo = magazineSize;
                reloading = false;
                ammoText.setText(currentAmmo);
                roundAmmoText.setText(round);
                Debug.Log("Reloaded");
            }

        }
    }

    //Used for the interaactions of the gun after the player shoots with it.
    public void Shoot()
    {
        //Raycast to set the projectile that the gun shoots.
        RaycastHit hit;
        
        //Checks to see if an enemy is hit by the projectile created.
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            //Debug.Log(enemy);

            //If an enemy is hit
            if(enemy != null)
            {
                Debug.Log("Enemy hit");
                enemy.takeDamage(this.damage);
            }
        }

        //Used to shoot ammunition if there is still ammunition left in the game.
        if (currentAmmo > 0)
        {
            currentAmmo--;
            ammoText.setText(currentAmmo);
            //Debug.Log("Shot ");
        }
        
    }

}
