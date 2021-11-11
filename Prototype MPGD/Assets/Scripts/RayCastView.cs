using UnityEngine;
using System.Collections;

//A script used for the projectile shot by the Gun object for interactions with the Enemy objects and later on pickups.
public class RayCastView : MonoBehaviour
{


    //Variables to be used.
    public float fireRate = 0.25f;
    public float weaponRange = 50f;

    //Set the point at which the gun projectile will come from.
    public Transform gunEnd;

    //Set the point that the projectile's path will follow.
    private Camera fpsCam;

    //Set the Line object used to display the projectile being shot.
    private LineRenderer laserLine;

    private float nextFire;

    //Used to first call upon the line displaying the projectile being shot and also the camera used to determine the trajectory of the gun.
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        fpsCam = Camera.main;
    }


    void Update()
    {
        //Used to determine the trajectory of the projectile based on mouse input whenever the player does a mouse click.
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);

            //If an object is hit by the projectile.
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);

            }

            //If an object is not hit by the projectile.
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }
    }

    //Used to render the projectile being shot by the Gun object and setting a limit to how often it can be displayed via a 'Wait' call.
    private IEnumerator ShotEffect()
    {

        laserLine.enabled = true;

        yield return new WaitForSeconds(0.2f);

        laserLine.enabled = false;
    }
}