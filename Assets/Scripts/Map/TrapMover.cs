using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMover : MonoBehaviour
{
    public float velocity = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rot = Time.realtimeSinceStartup * velocity % 360f;
        transform.rotation = Quaternion.Euler(0f,0f,rot);
    }
}
