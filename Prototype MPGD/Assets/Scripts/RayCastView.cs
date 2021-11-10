using UnityEngine;
using System.Collections;

public class RayCastView : MonoBehaviour
{

    public float fireRate = 0.25f;
    public float weaponRange = 50f;

    public Transform gunEnd;

    private Camera fpsCam;
    private LineRenderer laserLine;
    private float nextFire;


    void Start()
    {
        laserLine = GetComponent<LineRenderer>();

        fpsCam = Camera.main;
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);

            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }
    }


    private IEnumerator ShotEffect()
    {

        laserLine.enabled = true;

        yield return new WaitForSeconds(0.2f);

        laserLine.enabled = false;
    }
}