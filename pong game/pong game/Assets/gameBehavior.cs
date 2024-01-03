using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameBehavior : MonoBehaviour
{
    [SerializeField] Transform leftRacket;
    [SerializeField] Transform rightRacket;
    [SerializeField] Rigidbody2D Ballobj;

    public float speed = 30;
    // Start is called before the first frame update
    void Start()
    {
        Ballobj.velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        keyboard();
    }

    void keyboard()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            rightRacket.position += Vector3.up;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            rightRacket.position += Vector3.down;

        if (Input.GetKeyDown(KeyCode.W))
            leftRacket.position += Vector3.up;
        if (Input.GetKeyDown(KeyCode.S))
            leftRacket.position += Vector3.down;
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight)                     //not done in class
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D(Collision2D col)                    //not done in class
    {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider

        // Hit the left Racket?
        if (col.gameObject.name == "leftRacket")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            Ballobj.velocity = dir * speed;
        }

        // Hit the right Racket?
        if (col.gameObject.name == "rightRacket")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            Ballobj.velocity = dir * speed;
        }
    }
}
