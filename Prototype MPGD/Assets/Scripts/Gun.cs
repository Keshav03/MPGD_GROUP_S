
using UnityEngine;
using UnityEngine.UI;


public class Gun : MonoBehaviour
{

    public string gunName;
    public int damage;
    public int range;
    public float fireRate;
    //public int accuracy;

    public int round;
    public int magazineSize;
    public int currentAmmo;
    public bool reloading = false;

    public Camera playerCam;
    private float nextFire;

    public ChangeText ammoText;
    public ChangeText roundAmmoText;
    public ChangeText gunText;

    public Gun(string name1, int damage1, int range1, float fireRate1, int round1, int magazineSize1) {

        gunName = name1;
        damage = damage1;
        range = range1;
        fireRate = fireRate1;
        round = round1;
        magazineSize = magazineSize1;
        currentAmmo = magazineSize;
        
    }

    public void Start(){
        ammoText.setText(magazineSize);
        roundAmmoText.setText(round);
        gunText.setText(gunName);
    }


    public void update()
    {
         if (Input.GetButtonDown("Fire1") && currentAmmo > 0 && Time.time > nextFire)
         {
             nextFire = Time.time + fireRate;
             Shoot();
         }

         if (Input.GetKeyDown(KeyCode.R) && currentAmmo < magazineSize && !reloading)
         {
             reloading = true;
             Reload();
         }

    }

    public void Reload()
    {
        if(round == 0 ){
            Debug.Log("No Round Left");
            return;
        }
        else{
            if(currentAmmo == magazineSize){
                Debug.Log("Ammo Full");
            }else{
                round = (currentAmmo + round) - magazineSize;
                if(round<= 0 ){
                    round = 0;
                }
                currentAmmo = magazineSize;
                reloading = false;
                Debug.Log("Reloaded");
                ammoText.setText(currentAmmo);
                roundAmmoText.setText(round);
            }
            
        }
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            //Debug.Log(enemy);
            if(enemy != null){
                Debug.Log("works");
                enemy.takeDamage(this.damage);
            }
        }

        if (currentAmmo > 0){
            currentAmmo--;
            ammoText.setText(currentAmmo);
            // Debug.Log("Shot ");
        }
        
    }

}
