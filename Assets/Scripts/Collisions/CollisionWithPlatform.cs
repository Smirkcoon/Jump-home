using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithPlatform : MonoBehaviour
{
    private GameObject Player;
    public float jumpForce = 10f;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.relativeVelocity.y <= 0f)
            {
                Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 velocity = rb.velocity;
                    velocity.y = jumpForce;
                    rb.velocity = velocity;
                }
            }
        }
    }
    void Start() 
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (transform.position.y + 10 < Player.transform.position.y) 
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
