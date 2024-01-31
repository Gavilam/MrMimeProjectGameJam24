using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] FlowManager flowManager;
    //[SerializeField] List<IngredientList> lists;
    [SerializeField] StorageScript storage;

    [SerializeField] AudioSource source;
    [SerializeField] AudioClip subi;
    [SerializeField] AudioClip burbujas;

    //array
    public GameObject[] GOActivar;
    public float tiempo01, tiempo02, tiempo03;

    public Customer customer;

    public void Start()
    {
        customer = GetCustomer();
        Events.IngredientsDropped.AddListener(CheckIngredientList);
    }

    /*
    void SetNewRandomIngredientList()
    {
        ingredients.Clear();
        var allIngredients = Enum.GetValues(typeof(IngredientType));
        IngredientType newIngredient;

        for (int i = 0; i < ingredientAmount; i++)
        {
            do
            {
                newIngredient 
            }
            ingredients.Add())
        }
    }*/

    private Customer GetCustomer()
    {
        Debug.Log("Longitud = " + storage.customers.Length);
        Debug.Log("N = " + storage.n_customer);
        return storage.customers[storage.n_customer];
    }

    void CheckIngredientList(List<IngredientType> list)
    {
        bool correntMatch = true;

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] != customer.recipe[i])
            {
                correntMatch = false;
                break;
            }
        }

        customer.success = correntMatch;
        Debug.Log("Resultado: " + correntMatch);


        StartCoroutine(AnimateRisingPotionCorrutina());
    }

    IEnumerator AnimateRisingPotionCorrutina()
    {
        //quitar mano
        GOActivar[0].SetActive(false);
        //poner humo hacer pocion
        GOActivar[1].SetActive(true);

        source.PlayOneShot(burbujas);

        yield return new WaitForSeconds(burbujas.length); //4

        //poner hacer pocion
        Debug.Log("Que suene la subida");
        source.PlayOneShot(subi);

        GOActivar[2].SetActive(true);
     
        yield return new WaitForSeconds(tiempo02); //3

        //activar carabruja fase 1
        GOActivar[3].SetActive(true);
        //pone fade fase 2
        yield return new WaitForSeconds(tiempo03);
        GOActivar[4].SetActive(true);

        


        yield return new WaitForSeconds(tiempo02);

        //cambio escena
        flowManager.ChangeToNextScene();
    }


}
