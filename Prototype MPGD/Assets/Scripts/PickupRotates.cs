using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRotates : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(1f,1f,1f));
    }
}