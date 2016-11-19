using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnCommand : Command {


	public override void Execute (Transform actor, Command command)
	{

		List<Command> oldCommands = InputHandler.oldCommands;

		if(oldCommands.Count > 0)
		{

			Command ultimoCommand = oldCommands[oldCommands.Count -1];

			//Mueve el actor con este command
			ultimoCommand.Undo(actor);

			//Borra el ultimo command
			oldCommands.RemoveAt(oldCommands.Count - 1);

		}

	}

}
