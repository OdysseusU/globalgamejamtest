using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementCharacter : MonoBehaviour
{

    [SerializeField]
    private float Speed = 5F;
    [SerializeField]
    private Rigidbody2D CharacterRigidBody;
    //Used to convert pixel unit from the mouse position to game unit
    [SerializeField]
    private Camera Camera;
    
    private Vector2 mVector;
    private Vector2 mMousePosition;
    private Vector2 mLookPosition;

    private float mAngleToRotateCharacter;

    private float mLifeCharacter;
    public event Action<float> OnLifeDamaged;

    private bool mInvulnerable;

    private void Start()
    {
        CharacterRigidBody = this.GetComponent<Rigidbody2D>();
        mLifeCharacter = 100F;
        mInvulnerable = false;
    }
    // Update is called once per frame
    void Update()
    {
        mVector.x = Input.GetAxisRaw("Horizontal");
        mVector.y = Input.GetAxisRaw("Vertical");
        mMousePosition =  Camera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonDown("Fire1"))
        {
            ShootProj();
        }
    }

    private void FixedUpdate()
    {
        CharacterRigidBody.MovePosition(CharacterRigidBody.position + mVector * Time.fixedDeltaTime * Speed);
        mLookPosition = mMousePosition - CharacterRigidBody.position;

        mAngleToRotateCharacter = Mathf.Atan2(mLookPosition.y, mLookPosition.x) * Mathf.Rad2Deg;

        CharacterRigidBody.rotation = mAngleToRotateCharacter;
    }

    private void ShootProj()
    {
        mMousePosition = Camera.ScreenToWorldPoint(Input.mousePosition);
        
        //GameObject lProjectile = Instantiate(ProjectileType, StartProjectile.position, StartProjectile.rotation);
        //Rigidbody2D lRigidBody = lProjectile.GetComponent<Rigidbody2D>();
        //lRigidBody.AddForce((mMousePosition - StartProjectile.position) * mBulletForce, ForceMode2D.Impulse);

    }

    private void LifeDamaged(float iDamage)
    {

        if(mLifeCharacter - iDamage > 0 && !mInvulnerable)
        {
            mInvulnerable = true;
            mLifeCharacter -= iDamage;
            //Dans le cas où l'on a de l'UI pour afficher la life
            if (OnLifeDamaged != null)
                OnLifeDamaged(mLifeCharacter);
            StartCoroutine(ResetInvulnerability());
        }
        else if(mLifeCharacter < 0)
        {
            //Animation mort du perso ou relancer le level
        }

    }

    private IEnumerator ResetInvulnerability()
    {
        yield return new WaitForSeconds(1F);
        mInvulnerable = false;
    }
}



