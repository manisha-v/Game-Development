using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectile;
    private Transform projectileSpawn;

    public float nextFire = 3.0f;
    public float currentTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        projectileSpawn = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    public void shoot()
    {
        currentTime += Time.deltaTime;

        if (currentTime > nextFire)
        {
            nextFire += currentTime;
            Instantiate(projectile, projectileSpawn.position, Quaternion.identity);
            nextFire -= currentTime;
            currentTime = 0.0f;
        }
    }
}
