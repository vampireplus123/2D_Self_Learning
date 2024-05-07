using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Action : MonoBehaviour
{
    Animator anim;
    public int pressCount = 1;
    public bool isAttack = true;

    // Timer variables
    public float comboTimer = 0f;
    Movement customeMove;
    public float comboWindow = 0.5f; // Adjust this value to define the combo window duration

    void Start()
    {
        anim = GetComponent<Animator>();
        comboTimer = comboWindow;
        customeMove = GetComponent<Movement>();
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        comboTimer -= Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && comboTimer <=0){
            isAttack = true;
            countAnimation();
            comboTimer = comboWindow;
        }
        else if(Input.GetMouseButtonDown(0) && comboTimer >0)
        {
            isAttack = true;
            pressCount++;
            if(pressCount > 3){
                pressCount = 1;
            }
            countAnimation();
            comboTimer = comboWindow;
        }
        else if(comboTimer < 0 && !Input.GetMouseButtonDown(0)){
            isAttack = false;
        }
        if(comboTimer < 0){
            pressCount = 1;
        }
    }

    void countAnimation(){
        switch (pressCount)
        {
            case 1:
            Debug.Log("1");
            anim.SetTrigger("RPunch");
            break;
            case 2:
            Debug.Log("2");
            anim.SetTrigger("LPunch");
            break;
            case 3:
            Debug.Log("3");
            anim.SetTrigger("Kick");
            break;
        }
}
}
