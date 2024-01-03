using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //move player
        MovePlayer();
    }

    public void MovePlayer()
    {
        player.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
    }
    

}
