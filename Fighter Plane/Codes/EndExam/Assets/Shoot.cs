using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    private Transform projectileSpawn;
    //private Transform pos;
    public Vector3 pos;
    public float nextFire = 1.0f;
    public float currentTime = 0.0f;
    public AudioSource firingSound;

    
    // Start is called before the first frame update
    void Start()
    {
        //projectileSpawn = this.gameObject.transform;
        
        //projectileSpawn.position += new Vector3(200, 0,0);
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    public void shoot()
    {
        currentTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F) && currentTime > nextFire)
        {
            firingSound.Play();
            nextFire += currentTime;
            pos = this.gameObject.transform.position + new Vector3(1.8f, -0.2f, 0);
            //pos = PlayerScript.playerPos;
            Instantiate(projectile, pos, Quaternion.identity);
            nextFire -= currentTime;
            currentTime = 0.0f;
            
        }
    }

    
}
