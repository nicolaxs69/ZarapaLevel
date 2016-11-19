using UnityEngine;
using UnityEngine;
using System.Collections;
//Clase abstracta de la que heredaran todos los comandos del videojuego
//por eso, esta clase no debe heredar necesariamente de monobehavior


public abstract class Command
{

    //metodo abstracto para ejecutar el comando para el actor dado
    public abstract void execute(GameObject actor);

}
