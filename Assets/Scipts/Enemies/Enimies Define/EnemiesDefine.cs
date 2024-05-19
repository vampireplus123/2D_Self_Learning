using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Onre : Enemies
{
    public float speed = 5f;
    // public Transform player;
    void  Update(){
        Move(speed);
    }

    public override void Move(float speed)
    {
        base.Move(speed);
    }
    // You can override other methods specific to goblins
}