using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Onre : Enemies
{
    public float speed = 5f;
    // public Transform player;
    void  Update(){
        EnemiesController(speed);
    }

    public override void EnemiesController(float speed)
    {
        base.EnemiesController(speed);
    }
    // You can override other methods specific to goblins
}