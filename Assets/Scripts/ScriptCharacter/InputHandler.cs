using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour
{
    Animator anim;
    bool walking = false;
	bool isjumping = false;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

    }
		
    // Update is called once per frame
    void Update()
    {

		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

        Command turning = new Turning();
        Command movement = new Movement();
        Command jump = new Jump();

		animation(h,v);
		movement.execute(this.gameObject);

		anim.SetBool("isjumping",isjumping);
		      
		if (Input.GetButtonDown("Jump"))
        {
			if(isjumping == false)
			{
				isjumping = true;
				jump.execute(this.gameObject);

			}
        }
    }

	void landedFloor (Collision collision)
	{
		landed();
	}

	private void landed()
	{
		isjumping = false;
	}

	void animation (float h, float v)
	{
		walking = h != 0f || v != 0f ;
		anim.SetBool("iswalking", walking);
	}	


}