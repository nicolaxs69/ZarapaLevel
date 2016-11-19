﻿using UnityEngine;
using System.Collections;

public class MoveRight : Command {

	public override void Execute (Transform boxTrans, Command command)
	{
		//Move the box
		Move(boxTrans);

		//Save the command
		InputHandler.oldCommands.Add(command);
	}

	//Undo an old command
	public override void Undo(Transform boxTrans)
	{
		boxTrans.Translate(-boxTrans.right * moveDistance);
	}

	//Move the box
	public override void Move(Transform boxTrans)
	{
		boxTrans.Translate(boxTrans.right * moveDistance);
	} 
}
