using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySrcipt : MonoBehaviour
{
    private Rigidbody2D enemy;
    public float speed = 10.0f;

    private bool changeDirection = false;

    // Start is called before the first frame update
    void Start()
    {
        enemy = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveEnemy();
    }

    void moveEnemy()
    {
        if (changeDirection)
            enemy.velocity = new Vector2(1, 0) * (-1) * speed;
        else
            enemy.velocity = new Vector2(1, 0) * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "WallLeft")
                changeDirection = false;
        if (collision.gameObject.name == "WallRight")
                changeDirection = true;

    }

}
