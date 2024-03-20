using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public GameObject projectile;
    
    private float timeBetShots;
    public float startTimeBetShots;
    

    private void Start()
    {
        
        timeBetShots = startTimeBetShots;
    }


    public void Shoot()
    {
        if (timeBetShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetShots = startTimeBetShots;
        }
        else
        {
            timeBetShots -= Time.deltaTime;
        }
    }
}
