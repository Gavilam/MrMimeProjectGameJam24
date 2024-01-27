using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            Debug.Log("Flecha derecha");
            gameManager.ChangeToNextScene();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Flecha izquierda");
            gameManager.ChangeToPreviousScene();
        }
    }
}
