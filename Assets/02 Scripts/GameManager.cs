using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private string[] sceneNames = { "00TitleScene, 01ClientScene", "02BookScene", "03IngredientsScene", "04ResultScene", "05Credits"};
    private int currentScene;

    public void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

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
}
