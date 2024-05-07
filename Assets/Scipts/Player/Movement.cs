using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    CharacterController controller;
    float horizontal;
    Action action;
    Animator anim;
    // Start is called before the first frame update
    bool facingRight = true; // Indicates if the player is facing right initially
    void Start()
    {
        controller = GetComponent<CharacterController>();
        action = GetComponent<Action>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        if (horizontal != 0)
        {
            moveDirection();
            if (horizontal < 0 && facingRight)
            {
                flip();
            }
            else if (horizontal > 0 && !facingRight)
            {
                flip();
            }
        }
        else{
            anim.SetBool("isRun",false);
        }
    }

    public void moveDirection()
    {   
        anim.SetBool("isRun",true);
        Vector3 direction = new Vector3(horizontal, 0, 0);
        controller.Move(direction);
    }

    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
