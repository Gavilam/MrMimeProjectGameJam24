using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] FlowManager flowManager;
    [SerializeField] List<IngredientList> lists;

    [SerializeField] PotionResult potionResult;

    public void Start()
    {
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

    void CheckIngredientList(List<IngredientType> list)
    {
        bool correntMatch = true;

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] != lists[0][i])
            {
                correntMatch = false;
                break;
            }
        }

        potionResult.success = correntMatch;
        flowManager.ChangeToNextScene();
    }
}
