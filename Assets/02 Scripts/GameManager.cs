using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] FlowManager flowManager;
    //[SerializeField] List<IngredientList> lists;
    [SerializeField] StorageScript storage;

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

        AnimateRisingPotion();
        
        flowManager.ChangeToNextScene();
    }

    private void AnimateRisingPotion()
    {

    }
}
