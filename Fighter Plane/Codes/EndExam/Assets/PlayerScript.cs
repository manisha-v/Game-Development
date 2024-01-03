using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    private  Rigidbody2D plane;
    public GameOverScript gameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 2.0f;
        plane = GetComponent<Rigidbody2D>();
        plane.velocity = new Vector2(speed,0);//Vector2.right * speed;
        //this.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            plane.transform.position = new Vector2(plane.position.x, plane.position.y + 0.05f);
        if (Input.GetKey(KeyCode.DownArrow))
            plane.transform.position = new Vector2(plane.position.x, plane.position.y - 0.05f);
        //plane.transform.position = new Vector2(plane.position.x, Input.GetAxis("Vertical"));
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name.StartsWith("enemy"))
        {
            Debug.Log("Collison");
             plane.velocity = new Vector2(0,0);
             gameOver.setup();

        }
        // if collide with wall destroy bullet
        else if (collision.gameObject.name.StartsWith("Wall"))
        {
            Destroy(this.gameObject);
        }
    }

    /* private void FixedUpdate()
     {
         //move player
         MovePlayer();
     }

     public void MovePlayer()
     {
         this.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
     }*/
}
