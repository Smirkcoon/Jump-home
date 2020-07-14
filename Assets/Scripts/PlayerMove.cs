using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 4.0f;
    private Rigidbody2D rb;
    private SpriteRenderer ThisSprite;
    private Camera MainCamera;
    public float damping = 1.5f;
    //public GameObject player1;
    //public GameObject player2;
    //public GameObject player3;
    public GameObject playerLeftClone;
    public GameObject playerRightClone;
    private SpriteRenderer LeftClone;
    private SpriteRenderer RightClone;
    void Start()
    {
        LeftClone = playerLeftClone.GetComponent<SpriteRenderer>();
        RightClone = playerRightClone.GetComponent<SpriteRenderer>();
        MainCamera = Camera.main;
        ThisSprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();      
    }
    void FixedUpdate()
    {
        if (Input.GetKey("right"))
        {
            rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
            ThisSprite.flipX = true;
            LeftClone.flipX = true;
            RightClone.flipX = true;
        }
        if (Input.GetKey("left"))
        {
            rb.AddForce(-transform.right * speed, ForceMode2D.Impulse);
            ThisSprite.flipX = false;
            LeftClone.flipX = false;
            RightClone.flipX = false;
        }
        if (transform.position.y < MainCamera.transform.position.y)
        {
            //Vector3 target;
            //target = new Vector3(0, transform.position.y, MainCamera.transform.position.z);           
            //Vector3 currentPosition = Vector3.Lerp(MainCamera.transform.position, target, damping * Time.deltaTime);
            //MainCamera.transform.position = currentPosition;
        }
        if (transform.position.x > 6.5f)
        {
            transform.position = playerLeftClone.transform.position;
        }
        if (transform.position.x < -6.5f)
        {
            transform.position = playerRightClone.transform.position;
        }
    }
    
}
