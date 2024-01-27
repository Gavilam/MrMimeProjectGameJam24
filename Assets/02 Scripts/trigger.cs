using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public Animator animator;
    public string nombreDeTrigger = "trigger_lanzar";


    //array de gameObjects
    public GameObject[] GOActivar;
    public GameObject[] GOPersonajes; //0 Base , 1 exito, 0 fallo



    void Update()
    {
        //Pulsar Espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Activar la animaci�n utilizando el trigger
            animator.SetTrigger(nombreDeTrigger);

            //Empezar corrutina
            StartCoroutine(Corrutina());
        }
    }
    
    IEnumerator Corrutina()
    {
        //Primero activar el GameObject Humo
        //Desactivar pocion
        //Segundo desactivar GO personaje 1
        //Segun resultado de pocion activar personaje 2 o 3 (suponiendo que 2 es exito y 3 fallo)
        //Activar GO Foco Trasero
        //Activar GO Luces

        yield return new WaitForSeconds(2);
        GOActivar[0].SetActive(true);
        //Meter cambio de personaje se muestra en funcion de exito o no. HAcer en otra funcion?
        yield return new WaitForSeconds(1);
        GOActivar[3].SetActive(false);
        GOPersonajes[0].SetActive(false);
        GOPersonajes[1].SetActive(true);


        yield return new WaitForSeconds(2);
        GOActivar[1].SetActive(true); //Activa foco trasero
        GOActivar[2].SetActive(true); //Activa Luces
    }
}