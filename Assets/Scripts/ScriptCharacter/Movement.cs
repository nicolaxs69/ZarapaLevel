using UnityEngine;
using System.Collections;

using System;

public class Movement : Command
{
    public float velocidad = 5f;
    Vector3 movement;
    public override void execute(GameObject actor)
    {
        move(actor);
    }
    
	public void move(GameObject actor)
    {
      	 float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * velocidad * Time.deltaTime;
        // Set the movement vector based on the axis input.

        movement.Set(h, 0f, v);

 

        // Move the player to it's current position plus the movement.
        actor.GetComponent<Rigidbody>().MovePosition(actor.transform.position + movement);

    }

}
