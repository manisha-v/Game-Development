using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    private Rigidbody2D projectile;
    public float moveSpeed ;
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 8f;
        projectile = this.gameObject.GetComponent<Rigidbody2D>();
        projectile.velocity = new Vector2(moveSpeed, 0);
        Debug.Log("speed = " + projectile.velocity);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collide with enemy = destroy/hide enemy n bullet

        if (collision.gameObject.name.StartsWith("enemy"))
        {
            sound.Play();
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
            ScoreScript.score++;
        }
        
    }
}
