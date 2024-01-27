using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public Animator animator;
    public string nombreDeTrigger = "trigger_lanzar";


    //array de gameObject
    public GameObject[] gameObjectActivar;

    void Start()
    {
        gameObjectActivar = new GameObject[6];
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        //Pulsar Espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Activar la animación utilizando el trigger
            animator.SetTrigger(nombreDeTrigger);
        }
    }

    IEnumerator Corrutina()
    {
        //Primero activar el GameObject Humo
        //Segundo desactivar GO personaje 1
        //Segun resultado de pocion activar personaje 2 o 3 (suponiendo que 2 es exito y 3 fallo)
        //Activar GO Foco Trasero
        //Activar GO Luces

        test.gameobject.setActive(true);
        yield new WaitforSeconds(2);
        test2.gameobject.setActive(true);
    }
}
