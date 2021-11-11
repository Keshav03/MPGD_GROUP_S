using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script used for the Camera that is used for the player's point of view.
public class CameraFollow : MonoBehaviour
{
    //Variables to be used.
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;

    //Used to check at every frame if a camera following the player is active or not and alter it as needed.
    private void Update()
    {
        Refresh();
    }

    //Function used to check if a camera is following player and if it is, alter as needed.
    public void Refresh()
    {
        //If no camera is following player
        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        //Compute position.
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition); //If positioning is okay.
        }
        else
        {
            transform.position = target.position + offsetPosition; //If positioning is not okay.
        }
        
        //Compute rotation.
        if (lookAt)
        {
            transform.LookAt(target); //If rotation is okay.
        }
        else
        {
            transform.rotation = target.rotation; //If rotation is not okay.
        }
    }
}