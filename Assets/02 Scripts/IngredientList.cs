using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IngredientList : ScriptableObject
{
    public List<IngredientType> ingredients;

    public IngredientType this [int index]
    {
        get => ingredients[index];
    }

}
