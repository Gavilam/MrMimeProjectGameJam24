using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events
{
    public class IngredientListEvent : UnityEvent<List<IngredientType>> { };

    public static UnityEvent TimeOver = new UnityEvent();

    public static IngredientListEvent IngredientsDropped = new IngredientListEvent();
}
