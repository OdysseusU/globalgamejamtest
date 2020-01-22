using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private Transform StartProjectile;
    [SerializeField]
    private GameObject ProjectileType;

    [SerializeField]
    private float mBulletForce = 20F;

    private Vector3 mMousePosition;
    [SerializeField]
    private Camera Camera;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Shoot"))
        {
            ShootProj();
        }
    }

    private void ShootProj()
    {
        mMousePosition = Camera.ScreenToWorldPoint(Input.mousePosition);

        GameObject lProjectile = Instantiate(ProjectileType, StartProjectile.position, StartProjectile.rotation);
        Rigidbody2D lRigidBody = lProjectile.GetComponent<Rigidbody2D>();
        lRigidBody.AddForce((mMousePosition - StartProjectile.position)  * mBulletForce, ForceMode2D.Impulse);
    }
}