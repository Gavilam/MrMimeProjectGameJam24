using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)){
            gameManager.ChangeToNextScene();
        }
        else if (Input.GetKeyDown(KeyCode.Delete))
        {
            gameManager.ChangeToPreviousScene();
        }
    }

}
