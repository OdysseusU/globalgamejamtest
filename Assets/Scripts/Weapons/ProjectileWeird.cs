using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeird : Projectile
{
    private float time = 0f;
    private Vector3 fromPosition;
    private Vector3 toPosition;
    // Start is called before the first frame update
    void Start()
    {
        fromPosition = transform.position;
        toPosition = transform.position + transform.up * velocity;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.position = Vector3.Lerp(fromPosition, toPosition, time);
        transform.position += transform.right * Mathf.Sin(time * 2 * Mathf.PI);
        if (time > 1f)
        {
            time = 0f;
            fromPosition = transform.position;
            toPosition = transform.position + transform.up * velocity;
        }
    }
}
