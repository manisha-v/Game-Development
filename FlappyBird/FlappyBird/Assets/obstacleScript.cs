using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleScript : MonoBehaviour
{
    
    public float speed = 1;
    public float switchTime;
    // Start is called before the first frame update
    void Start()
    {
        switchTime = Random.Range(1, 5);
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        InvokeRepeating("Switch", 0, switchTime);
    }

    void Switch()
    {      
        GetComponent<Rigidbody2D>().velocity *= -1; 
    }

    
}
