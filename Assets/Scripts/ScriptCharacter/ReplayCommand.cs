using UnityEngine;
using System.Collections;

public class ReplayCommand : Command {


	public override void Execute (Transform actor, Command command)
	{

		InputHandler.shouldStartReplay = true;
	}

}
