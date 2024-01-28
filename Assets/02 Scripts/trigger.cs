using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public Animator animator;
    public string nombreDeTrigger = "trigger_lanzar";
    public float tiempo01, tiempo02, tiempo03;

    //array de gameObjects
    public GameObject[] GOActivar;
    public GameObject[] GOPersonajes; //0 Base , 1 exito, 0 fallo
    [SerializeField] StorageScript storage;
    [SerializeField] GameObject customer_object;
    private SpriteRenderer customerSprite;
    public Customer customer;

    private void Start()
    {
        customer = GetCustomer();
        //Events.CustomerReady?.Invoke();
        SetCustomer();
    }

    void Update()
    {
        //Pulsar Espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Activar la animación utilizando el trigger
            animator.SetTrigger(nombreDeTrigger);

            //Empezar corrutina
            StartCoroutine(Corrutina());
        }
    }

    private Customer GetCustomer()
    {
        return storage.customers[storage.n_customer];
    }

    private void SetCustomer()
    {
        customerSprite = customer_object.GetComponent<SpriteRenderer>();
        customerSprite.sprite = customer.image;
        customer_object.SetActive(true);
    }

    IEnumerator Corrutina()
    {
        //Primero activar el GameObject Humo
        //Desactivar pocion
        //Segundo desactivar GO personaje 1
        //Segun resultado de pocion activar personaje 2 o 3 (suponiendo que 2 es exito y 3 fallo)
        //Activar GO Foco Trasero
        //Activar GO Luces

        yield return new WaitForSeconds(tiempo01);
        GOActivar[0].SetActive(true);

        //Meter cambio de personaje se muestra en funcion de exito o no. HAcer en otra funcion?
        yield return new WaitForSeconds(tiempo02);
        GOActivar[3].SetActive(false);
        //GOPersonajes[0].SetActive(false);
        //GOPersonajes[1].SetActive(true);

        Debug.Log("Resultado Scene - " + customer.success);
        if (customer.success)
        {
            customerSprite.sprite = customer.goodResult;
        }
        else
        {
            customerSprite.sprite = customer.badResult;
        }


        yield return new WaitForSeconds(tiempo03);
        GOActivar[1].SetActive(true); //Activa foco trasero
        GOActivar[2].SetActive(true); //Activa Luces
    }
}
