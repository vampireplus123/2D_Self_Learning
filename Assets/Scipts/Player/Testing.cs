using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
// using UnityEngine.Windows;

public class Testing : MonoBehaviour
{
    Animator anim;
    int pressCount;
    public bool isAttack;
    // Start is called before the first frame update
    void Start()
    {
        pressCount = 0;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

// Move Animation use float parameter so that function must have parameter
// It cast with Movement scipt
   public void Attack()
    {
       if(Input.GetMouseButtonDown(0))
       {
            Debug.Log(pressCount);
            StartAttack();
       }else{
            resetAnimation();
       }
    }

    void StartAttack()
    {
        isAttack = true;
        pressCount ++;
        AttackAnimation();
    }
    void resetAnimation(){
        isAttack = false;
        if(pressCount > 3){
            pressCount = 0;
        }
    }

    void AttackAnimation()
    {
       switch (pressCount)
       { 
        case 1:
        anim.SetTrigger("RPunch");
        break;
        case 2:
        anim.SetTrigger("LPunch");
        break;
        case 3:
        anim.SetTrigger("Kick");
        break;
       }
      resetAnimation();
    }

}