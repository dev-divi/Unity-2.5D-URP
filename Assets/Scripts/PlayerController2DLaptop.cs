using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2DLaptop : MonoBehaviour
{ 

    public float floatForce = 50;//jump float
    public float levitation = 5; 
    private float gravityModifier = 1.5f; //jump, moon gravity basically 

    public float speed = 10.0f; 
    public bool isOnGround = true; 
    private Rigidbody2D playerRb;


    // Start is called before the first frame update
    void Start()
    {
        
        playerRb = GetComponent<Rigidbody2D>(); //get component 
        Physics.gravity *= gravityModifier;

     }

    // Update is called once per frame    
    void Update()
    {
        
        BoundariesPlayer();
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical"); 
        
        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
        
        if (Input.GetKey(KeyCode.Space)) {
            playerRb.AddForce(Vector3.up * floatForce);
            isOnGround = false; 
        }

    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            playerRb.AddForce(Vector3.up * levitation, ForceMode2D.Impulse);
        }

    }

    void BoundariesPlayer()
    {
        //up down zeta // unneeded for 2d 
        //if (transform.position.z >= 70f) {
        //    transform.position = new Vector3(transform.position.x, transform.position.y, -35f);
        //}
        //else if (transform.position.z <= -35f)
        //{
        //    transform.position = new Vector3(transform.position.x, transform.position.y, 70f);
        //}
        //horizontal
        if (transform.position.x >= 30f) {
            transform.position = new Vector3(30f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -8)
        {
            transform.position = new Vector3(-8, transform.position.y, transform.position.z);
        }
        //vertical
        if (transform.position.y >= 8) { 
            transform.position = new Vector3(transform.position.x, 8, transform.position.z);
        }
        else if (transform.position.y <= -7) //respawns player from top 
        {
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        }

    }
}
