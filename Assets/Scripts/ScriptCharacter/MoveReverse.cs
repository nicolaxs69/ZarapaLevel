﻿using UnityEngine;
using System.Collections;

public class MoveReverse : Command {


	public override void Execute(Transform actor, Command command)
	{
		//Move the box
		Move(actor);

		//Save the command
		InputHandler.oldCommands.Add(command);
	}

	//Undo an old command
	public override void Undo(Transform actor)
	{
		actor.Translate(actor.forward * moveDistance);
	}

	//Move the box
	public override void Move(Transform actor)
	{
		actor.Translate(-actor.forward * moveDistance);
	} 



}
