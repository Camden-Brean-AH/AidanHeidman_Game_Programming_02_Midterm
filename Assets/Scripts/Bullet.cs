using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float rotation = 0.0f;
    float rotationSpeed = 250.0f * Mathf.Deg2Rad;
    float Speed = 5;
    public float SpawnTime;
    // Start is called before the first frame update
    private void Start()
    {
        SpawnTime = Time.time;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            if (collision.gameObject.tag == "Bullet")
            {
                if (collision.gameObject.GetComponent<Bullet>().SpawnTime > SpawnTime)
                {
                    Destroy(gameObject);
                }
            }
            else Destroy(gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        Vector3 direction = new Vector3(Mathf.Cos(rotation), Mathf.Sin(rotation), 0.0f);
        transform.position += direction * Speed * dt;
        //Debug.DrawLine(transform.position, transform.position + direction * 10.0f);
    }
}
