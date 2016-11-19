using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour
{
    Animator anim;
    bool walking = false;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Command turning = new Turning();
        Command movement = new Movement();
        Command jump = new Jump();

        if ((Input.GetButtonDown("Horizontal")) || (Input.GetButtonDown("Vertical")))
        {
            walking = true;
            
        }
    
        movement.execute(this.gameObject);
        turning.execute(this.gameObject);
      
        if (Input.GetButtonDown("Jump"))
        {
            jump.execute(this.gameObject);
        }
    }
}