using UnityEngine;
using System.Collections;
//Clase abstracta de la que heredaran todos los comandos del videojuego
//por eso, esta clase no debe heredar necesariamente de monobehavior


public abstract class Command
{

	protected float moveDistance = 1f;

	//metodo abstracto para ejecutar el comando para el actor dado
	public abstract void Execute(Transform actor, Command command);

	//Undo an old command
	public virtual void Undo(Transform boxTrans) { }

	//Move the box
	public virtual void Move(Transform boxTrans) { }



}
