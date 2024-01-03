using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    private Rigidbody2D projectile;
    public float moveSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        projectile = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        projectile.velocity = new Vector2(0, 1) * moveSpeed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collide with enemy = destroy/hide enemy n bullet

        if (collision.gameObject.name.StartsWith("Enemy"))
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
