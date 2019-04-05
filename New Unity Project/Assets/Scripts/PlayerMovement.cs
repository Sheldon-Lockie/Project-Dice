using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigid;
    private KeyCode Jump = KeyCode.Space;
    private KeyCode Backward = KeyCode.W;
    private KeyCode Foward = KeyCode.S;
    private KeyCode Left = KeyCode.A;
    private KeyCode Right = KeyCode.D;
    private bool IsOnGround = false;
    private float MaxXVelocity = 1;
    private float MaxZVelocity = 1;
    // Start is called before the first frame update
    void Start()
    {
        rigid.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOnGround == true)
        {
            if (Input.GetKey(Jump))
            {
                rigid.AddForce(0f, 150f, 0f);
                IsOnGround = false;
                Debug.Log("Space Pressed");
            }

        }
        if (rigid.velocity.x < MaxXVelocity)
        {
            if (Input.GetKey(Left))
            {
                rigid.AddForce(-1f, 0f, 0f);
            }
            if (Input.GetKey(Right))
            {
                rigid.AddForce(1f, 0f, 0f);
            }

        }
        if(rigid.velocity.z < MaxZVelocity)
        {
            if (Input.GetKey(Foward))
            {
                rigid.AddForce(0f, 0f, -1f);
            }
            if (Input.GetKey(Backward))
            {
                rigid.AddForce(0f, 0f, 1f);
            }
        }

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        IsOnGround = true;
    }
}
