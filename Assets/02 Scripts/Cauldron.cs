using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    List<IngredientType> droppedIngredients;


    private void Awake()
    {
        droppedIngredients = new List<IngredientType>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FallingIngredient"))
        {
            droppedIngredients.Add(collision.GetComponent<Ingredient>().type);

            Destroy(collision.gameObject);

            if (droppedIngredients.Count == 3)
            {
                Events.IngredientsDropped.Invoke(droppedIngredients);
                droppedIngredients.Clear();
            }
        }
    }
}
