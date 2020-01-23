using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float frequency = 1f;
    public float price = 1f;

    private float time = 0f;

    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    public void shoot()
    {
        if(time > 1f/frequency)
        {
            GameObject inst = Instantiate(projectile, transform.position, transform.rotation);
            time = 0f;
        }
    }
}
