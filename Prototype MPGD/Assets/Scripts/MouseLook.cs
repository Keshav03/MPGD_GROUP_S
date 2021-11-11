using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A script used for the player's mouse to be used as the basis of movement for the Player object.
public class MouseLook : MonoBehaviour
{
    //Variables to be used.
    public float mouseSensitivity  = 100f;
    public Transform player;
    float xRotation = 0f;



    //Used to constrain the mouse pointer to the centre of the point of view of the game when the game starts.
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Used to update the position of the Player's point of view based on mouse input.
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-45f,45);

        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        player.Rotate(Vector3.up * mouseX);

    }
}
