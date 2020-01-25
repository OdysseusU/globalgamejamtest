using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public float period = 3f;
    public float offset = 0f;
    public float timeAlive = 1f;

    public float damage = 1f;

    private Collider2D collider2d;
    private SpriteRenderer spriteRenderer;

    private float timeLeft = 0f;
    private bool alive = false;
    // Start is called before the first frame update
    void Start()
    {
        collider2d = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(period == 0)
        {
            collider2d.enabled = true;
            spriteRenderer.enabled = true;
            timeLeft = 0f;
            alive = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(period == 0)
        {
            return;
        }
        if((Time.realtimeSinceStartup+offset)%period < 0.1f)
        {
            collider2d.enabled = true;
            spriteRenderer.enabled = true;
            timeLeft = 0f;
            alive = true;
        }

        if (alive)
        {
            timeLeft += Time.deltaTime;
            if(timeLeft > timeAlive)
            {
                collider2d.enabled = false;
                spriteRenderer.enabled = false;
                alive = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CharacterAction>() != null)
            GameManager.instance.Character.GetComponent<CharacterAction>().LifeDamaged(damage);
        if (collision.gameObject.GetComponent<AMonster>() != null)
            collision.gameObject.GetComponent<AMonster>().LoseHp(damage);

    }
}
