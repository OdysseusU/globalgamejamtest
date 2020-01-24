using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float velocity = 1f;
    public float damage = 1f;

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
        if (time > 1f)
        {
            time = 0f;
            fromPosition = transform.position;
            toPosition = transform.position + transform.up * velocity;
        }
    }

    protected virtual void triggerCollider(Collider2D collision)
    {
        GameObject.Destroy(this.gameObject);
        //remove other life
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerCollider(collision);
    }
}
