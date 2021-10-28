
using UnityEngine;

public class gun : MonoBehaviour
{

    public string gunName;
    public int damage;
    public int range;
    public int fireRate;
    //public int accuracy

    public int round;
    public int magazineSize;
    public int currentAmmo;
    public bool reloading = false;

    public Camera playerCam;
    private float nextFire;

    public gun(string name1, int damage1, int range1, int fireRate1, int round1, int magazineSize1, int currentAmmo1) {

        gunName = name1;
        damage = damage1;
        range = range1;
        fireRate = fireRate1;
        round = round1;
        magazineSize = magazineSize1;
        currentAmmo = currentAmmo1;
        
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
        round = (currentAmmo + round) - magazineSize;
        currentAmmo = magazineSize;
        reloading = false;
    }

    public void Shoot()
    {

        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {

            //Enemy is equal to enemy Object 
            //Enemy target = hit.transform.GetComponent<Enemy>();

            //if (target != null)
            //{
            //    target.takeDamage();
            //}
            currentAmmo--;
        }

    }

}
