using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
    private float mLife;

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

    private void Start()
    {
        CharacterRigidBody = this.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        mVector.x = Input.GetAxisRaw("Horizontal");
        mVector.y = Input.GetAxisRaw("Vertical");
        mMousePosition =  Camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        CharacterRigidBody.MovePosition(CharacterRigidBody.position + mVector * Time.fixedDeltaTime * Speed);
        mLookPosition = mMousePosition - CharacterRigidBody.position;

        mAngleToRotateCharacter = Mathf.Atan2(mLookPosition.y, mLookPosition.x) * Mathf.Rad2Deg;

        CharacterRigidBody.rotation = mAngleToRotateCharacter;
    }
}
