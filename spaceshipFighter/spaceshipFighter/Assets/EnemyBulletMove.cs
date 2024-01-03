using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMove : MonoBehaviour
{
    private Rigidbody2D Projectile;
    public float Speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Projectile = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Projectile.velocity = new Vector2(0, -1) * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name.StartsWith("player"))
        {
            collision.gameObject.SetActive(false);
        }
        // if collide with wall destroy bullet
        else if (collision.gameObject.name.StartsWith("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
