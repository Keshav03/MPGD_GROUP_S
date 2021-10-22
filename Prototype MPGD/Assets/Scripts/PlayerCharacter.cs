using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public int moveSpeed = 5;
    public int rotationSpeed = 2;
    public int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;


        transform.Rotate(Vector3.up* Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);

    }
    void Damage(int value)
    {
        health -= value;

    }
    void Shoot()
    {

    }
}
