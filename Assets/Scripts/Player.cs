using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    

    public float rotation = 0.0f;
    float rotationSpeed = 250.0f * Mathf.Deg2Rad;
    float Speed = 5;

    void Start()
    {
        // Example code to create a bullet and change its velocity:
        
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        float dt = Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            rotation += rotationSpeed * dt;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotation -= rotationSpeed * dt;
        }
        
        

        Vector3 direction = new Vector3(Mathf.Cos(rotation), Mathf.Sin(rotation), 0.0f);
        Debug.DrawLine(transform.position, transform.position + direction * 1.0f);
        
        // Task 1: Move the player forwards when W is held, and backwards when D is held
        // Ensure movement is time-based

        if (Input.GetKey(KeyCode.W))
        {
        
            transform.position += direction * Speed * dt;
            
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= direction * Speed * dt;

        }

        // Task 2: Create a bullet when space is pressed
        // Ensure the bullet is not touching the player when it's created
        if (Input.GetKeyDown(KeyCode.Space))
        {

            GameObject bulletClone =  Instantiate(bullet, transform.position + direction, Quaternion.EulerRotation(direction));
            bulletClone.GetComponent<Bullet>().rotation = rotation;
        }
    }
}
