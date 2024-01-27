using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private string[] sceneNames = { "00TitleScene, 01ClientScene", "02BookScene", "03IngredientsScene", "04ResultScene", "05Credits"};
    private int currentScene;

    [SerializeField] List<IngredientList> lists;

    [SerializeField] PotionResult potionResult;

    public void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

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

    

    /********************** CAMBIOS DE ESCENA ************************************/

    public void ChangeToScene(int sceneNumber)
    {
        currentScene = sceneNumber;
        SceneManager.LoadScene(sceneNames[sceneNumber]);
    }

    public void ChangeToNextScene()
    {
        if (currentScene != sceneNames.Length)
        {
            currentScene++;
            Debug.Log("Cambia a escena" + currentScene);
            SceneManager.LoadScene(currentScene);
        }
        else
        {
            Debug.Log("No hay escena siguiente");
        }
    }

    public void ChangeToPreviousScene()
    {
        if(currentScene != 0)
        {
            currentScene --;
            SceneManager.LoadScene(currentScene);
            Debug.Log("Cambia a escena" + currentScene);
        }
        else
        {
            Debug.Log("Est�s en la primera escena");
        }
        
    }


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
        ChangeToNextScene();
    }
}
