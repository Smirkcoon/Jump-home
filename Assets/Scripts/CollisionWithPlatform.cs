using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithPlatform : MonoBehaviour
{
    //public float thrust = 10.0f;
    //private Collider2D box2d;
    //public GameObject PlayerDownPoint;
    //public Rigidbody2D Playerrb;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    box2d = GetComponent<BoxCollider2D>();
    //    //Playerrb = Player.GetComponent<Rigidbody2D>();

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (PlayerDownPoint.transform.position.y > transform.position.y) 
    //    {
    //        box2d.isTrigger = false;
    //    }
    //    if (PlayerDownPoint.transform.position.y < transform.position.y)
    //    {
    //        box2d.isTrigger = true;
    //    }
    //}
    //public void OnCollisionEnter2D(Collision2D col)
    //{

    //    if (col.gameObject.tag == "Player") 
    //    {          
    //        Playerrb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
    //    }
    //}

    private GameObject Player;
    public float jumpForce = 10f;
    private void OnCollisionStay2D(Collision2D collision)
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
