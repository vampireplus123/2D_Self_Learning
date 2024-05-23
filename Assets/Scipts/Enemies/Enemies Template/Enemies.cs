using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemies : MonoBehaviour
{
    public int health;
    public int damage;
    private GameObject PlayerObject;
    private Transform playerPosition;
    public float maxDis = 2f;
    public float minDis = 2f;
    Animator anim;

    void Start()
    {
        GetNeedComponent();
        DefinePlayer();
    }

    //-- Difination Of The Important Component:
        //-- Player
        //-- Component
        //-- Aniamtion Control
    private void DefinePlayer()
    {
         if (PlayerObject != null)
        {
            playerPosition = PlayerObject.transform;
        }
        else
        {
            Debug.LogError("Player object not found. Make sure the player has the 'Player' tag.");
        }
    }
    private void GetNeedComponent(){
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }
    protected virtual void AnimationController(string AnimationName, bool AnimationState)
    {
        try
        {
            anim.SetBool(AnimationName, AnimationState);
        }
        catch (Exception error)
        {
            // Handle the exception here, such as logging it or displaying an error message.
            Debug.LogError("An error occurred while setting animation: " + error.Message);
        }
    }
   // Action of the Enemy
        // Move
        // Fight
        // Die
    public virtual void EnemiesController(float speed)
    {
        Move(speed);
    }
    protected virtual void Move(float speed){
        if (playerPosition != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerPosition.position);
            if (distanceToPlayer <= maxDis)
            {
                // Calculate direction to the player
                Vector3 direction = (playerPosition.position - transform.position).normalized;
                // Only keep the x and y components for 2D
                direction.z = 0;
                
                // Move towards the player
                transform.position += direction * speed * Time.deltaTime;

                // Rotate to face the player
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, angle,0));
               AnimationController("Attack",false);
            }
            if(distanceToPlayer <= minDis + 1){
                AnimationController("Attack",true);
            }
        }
    }
    protected virtual void Die()
    {
        // Define death behavior
       AnimationController("Die",true);
    }
}
