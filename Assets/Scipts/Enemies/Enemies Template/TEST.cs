using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TEST : MonoBehaviour
{
    public int health;
    public int damage;
    private GameObject PlayerObject;
    private Transform playerPosition;
    public float maxDis = 10f;
    public float minDis = 5f;
    public float speed = 10f;


    void Start()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        if (PlayerObject != null)
        {
            playerPosition = PlayerObject.transform;
        }
        else
        {
            Debug.LogError("Player object not found. Make sure the player has the 'Player' tag.");
        }
    }
    void Update()
    {
        Move(speed);
    }
    public virtual void Move(float speed)
    {
        if (playerPosition != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerPosition.position);

            if (distanceToPlayer > minDis)
            {
                // Calculate direction to the player
                Vector3 direction = (playerPosition.position - transform.position).normalized;
                // Only keep the x and y components for 2D
                direction.z = 0;
                
                // Move towards the player
                transform.position += direction * speed * Time.deltaTime;

                // Rotate to face the player
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }

            if (distanceToPlayer <= maxDis)
            {
                // Attack the player
                Debug.Log("Close");
            }
        }
    }
}
