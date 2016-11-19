using UnityEngine;
using System.Collections;
using System;


//debe extender de command, debido al principio de sustitucion de liskov

public class Jump : Command
{

   
    //Es igual al padre, entonces implementamos el metodo abstracto del  padre
    public override void execute(GameObject actor)
    {
        jump(actor);
    }

    public void jump(GameObject actor)
    {
        actor.GetComponent<Rigidbody>().AddForce(Vector3.up * 120);
       
    }


}