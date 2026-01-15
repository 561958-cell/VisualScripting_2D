using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Challenge1_complete : MonoBehaviour
{
    public float speed = 1f;
    public Transform[] waypoints;
    private int waypointIndex = 0;



    void Update()
    {
        if (waypointIndex < waypoints.Length)
        {
            // Calculate the direction towards the current waypoint
            Vector3 direction = waypoints[waypointIndex].position - transform.position;

            // Calculate the angle to rotate around the z-axis
            float angleToRotate = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Rotate only around the z-axis
            transform.rotation = Quaternion.Euler(0f, 0f, angleToRotate);

            // Move the object forward towards the waypoint in the x and y axes
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            // Check if the object is close enough to the current waypoint
            if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < 0.1f)
            {
                waypointIndex++;
            }
        }
        else
        {
            Debug.Log("Reached all waypoints!");
            Destroy(gameObject);
        }

    }



    /*Challenge 1:
     *Modify the script to get the enemy to follow each 
     *point inside the waypoints array of Transform objects, 
     *once they reach the last point destroy the enemy. 
     *This is like the enemies in the tower defense game.
     */

    /*
     * Test 1: checks if the enemy is moving
     * Test 2: checks if the enemy is moving at the right speed
     * Test 3: checks if enemy facing in the direction he is moving
     * Test 4: checks if enemy facing in the direction he is moving
     * Test 5: checks if top enemy reached the end
     * Test 6: checks if bottom enemy reached the end
     * Test 7: checks if enemy are destroyed at the end
     */
}