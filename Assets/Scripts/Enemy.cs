using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject Player;
    float Speed = 2.5f;
    float Rotation = 0;
    float Opp;
    float Adj;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<Player>().gameObject;
        Player.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            float dt = Time.deltaTime;
            Adj = Player.transform.position.x - transform.position.x;
            Opp = Player.transform.position.y - transform.position.y;
            Rotation = Mathf.Atan(Opp / Adj);

            Vector3 direction = new Vector3(Mathf.Cos(Rotation), Mathf.Sin(Rotation), 0.0f);
            

            if (Player.transform.position.x < transform.position.x)
            {
                transform.position -= direction * Speed * dt;
                Debug.DrawLine(transform.position, transform.position + direction * -1.0f );
            }
            else
            {
                Debug.DrawLine(transform.position, transform.position + direction * 1.0f);
                transform.position += direction * Speed * dt;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") Destroy(collision.gameObject);
        if (collision.gameObject.tag == "Bullet") Destroy(gameObject);



    }
}
