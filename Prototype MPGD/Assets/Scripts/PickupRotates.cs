using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A script used for the rotation of the pickup objects.
public class PickupRotates : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(1f,1f,1f));
    }
}
