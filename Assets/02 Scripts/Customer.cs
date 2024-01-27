using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Customer : ScriptableObject
{
    public int id;
    public IngredientList recipe;
    public Sprite image;
    public Sprite goodResult;
    public Sprite badResult;
    public string[] textos;
    public bool exito;
}
