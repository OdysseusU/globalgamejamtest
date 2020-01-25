using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakMonster : AMonster
{
    private Transform mPositionCharacter;
    private float mMoveSpeed = 3F;
    private float mStep;
    private Vector3 mVectorCharacter;
    private Vector3 mVectorMonster;

    private float mLife;
    // Start is called before the first frame update
    void Start()
    {
        mPositionCharacter = GameManager.instance.Character.transform;
        mLife = 40F;
    }

    // Update is called once per frame
    void Update()
    {
        mStep = mMoveSpeed * Time.deltaTime;
        Move();
    }

    public override void Move()
    {
        mVectorCharacter = new Vector3(mPositionCharacter.position.x, mPositionCharacter.position.y, mPositionCharacter.position.z);
        mVectorMonster = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

        this.transform.position = Vector3.MoveTowards(mVectorMonster, mVectorCharacter, mStep);
        //if(Vector3.Distance(mVectorMonster,mVectorCharacter )< 0.001F)
        if(this.gameObject.GetComponent<Collider2D>().IsTouching(GameManager.instance.Character.GetComponent<Collider2D>()))
        {
            Debug.Log("WEAKMONSTER : Destroy this");
            GameManager.instance.Character.GetComponent<CharacterAction>().LifeDamaged(5F);
            //Deals des dommage au perso puis se détruit (animation)
            Destroy(gameObject);
        }
    }

    public override void Shoot()
    {

    }

    public override void LoseHp(float iDamage)
    {
        mLife -= iDamage;
        if(mLife <= 0)
            Destroy(gameObject);


    }

}
