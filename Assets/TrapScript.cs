using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public float period = 3f;
    public float offset = 0f;
    public float timeAlive = 1f;

    public float damage = 1f;

    private Collider2D collider;
    private SpriteRenderer spriteRenderer;

    private float timeLeft = 0f;
    private bool alive = false;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Time.realtimeSinceStartup+offset)%period < 0.1f)
        {
            collider.enabled = true;
            spriteRenderer.enabled = true;
            timeLeft = 0f;
            alive = true;
        }

        if (alive)
        {
            timeLeft += Time.deltaTime;
            if(timeLeft > timeAlive)
            {
                collider.enabled = false;
                spriteRenderer.enabled = false;
                alive = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
