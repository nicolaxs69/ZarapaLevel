using UnityEngine;
using System.Collections;

public class PathFollowing : MonoBehaviour {
    //Variables del script
    public bool isLoop = false;
    public bool isCyclic = false;
    public bool showPoints = false;
    public float velocidad = 0.0006f;
    public float velocidadAnim = 5.0f;
    //El camino que voy a recorrer.
    public GameObject path;


    //Total de puntos de espera del camino.
    private int totalPuntos = 0;
    private int puntoActual = 0;

    private bool recorriendo = true;
    private bool cambioDePunto = true;
    private float caminoPorRecorrer = 0;

    //Vectores de movimiento
    private Vector3 posicionInicial;
    private Vector3 posicionFinal;

    private Animator animator;

    // Use this for initialization
    void Start()
    {
        if (this.path != null) {
            this.totalPuntos = path.transform.childCount;

            imprimirPuntos();
            if (!showPoints)
               // if (showPoints)
                {
                ocultarPuntos();
            }
            
            irAPosicionInicial();

            animator = this.GetComponent<Animator>();
            animator.speed = velocidadAnim;
            animator.Play("ArmatureAction");
        }
    }

    // Update is called once per frame
    void Update () {
        if (this.path != null)
        {
            if (recorriendo)
            {
                if (cambioDePunto)
                {
                    obtenerPuntoInicialPuntoFinal(puntoActual);
                    cambioDePunto = false;
                }

                transform.position = Vector3.Lerp(posicionInicial, posicionFinal, caminoPorRecorrer);
                transform.LookAt(posicionFinal);

                caminoPorRecorrer = caminoPorRecorrer + velocidad;

                verificarSiYaLlegoAlPuntoFinal();

            }
            else
            {
                if (isLoop)
                {
                    reiniciarVariables();
                }
            }
        }
	}

    /**
     * Reinicia las variables.
     */
    void reiniciarVariables()
    {
        recorriendo = true;
        caminoPorRecorrer = 0.0f;
        
        if (!isCyclic)
        {
            cambioDePunto = true;
            puntoActual = 0;
        }
    }

    /*
     * Verificamos si llego al punto final.
     */
    void verificarSiYaLlegoAlPuntoFinal(){
        if (caminoPorRecorrer >= 1.0f)
        {
            caminoPorRecorrer = 0.0f;
            cambioDePunto = true;
            puntoActual++;

            if (esElUltimoPunto(puntoActual)) {
                if (isCyclic)
                {
                    cambioDePunto = false;

                    posicionInicial = leerPunto(this.path.transform.GetChild(puntoActual).transform.position);
                    posicionFinal = leerPunto(this.path.transform.GetChild(0).transform.position);
                    puntoActual = -1;
                }
                else
                {
                    recorriendo = false;
                }
            }
        }
    }

    /*
     * Devuelve true si es el ultimo punto
     */
    bool esElUltimoPunto(int punto)
    {
        return (punto >= this.totalPuntos - 1);
    }

    //Obtener el punto Inicial y Final del movimiento
    void obtenerPuntoInicialPuntoFinal(int siguientePunto)
    {
        if (!esElUltimoPunto(siguientePunto))
        {
            posicionInicial = leerPunto(this.path.transform.GetChild(siguientePunto).transform.position);
            posicionFinal = leerPunto(this.path.transform.GetChild(siguientePunto + 1).transform.position);
        }
    }

    /**
     * Lee las componentes X y Z de un punto
     * ignora y porque la arania debe siempre estar al suelo.
     */
    Vector3 leerPunto(Vector3 puntoALeer)
    {
        Vector3 vectorNuevo = new Vector3(puntoALeer.x,0,puntoALeer.z);
        return vectorNuevo;
    }

    /**
     * El enemigo al que se le asocia este script
     * toma como posicion inicial el primer punto.  
     */
    void irAPosicionInicial()
    {
        if (this.totalPuntos > 0)
        {
            transform.position = leerPunto(this.path.transform.GetChild(0).transform.position);
        }
    }

    /**
     * Imprime los puntos leidos
     */
    void imprimirPuntos()
    {
        for (int i = 0; i < totalPuntos; i++)
        {
            print("Puntos de espera:" + this.path.transform.GetChild(i));
        }
    }

    //Oculta todos los puntos
    void ocultarPuntos()
    {
        for (int i = 0; i < totalPuntos; i++)
        {
            this.path.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
