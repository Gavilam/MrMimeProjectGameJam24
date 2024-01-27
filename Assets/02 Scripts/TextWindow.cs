using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextWindow : MonoBehaviour
{
    [SerializeField] TMP_Text textUI;
    [SerializeField] string textToShow;
    [SerializeField] string textcontinue;
    [SerializeField] bool escribir;
    [SerializeField] GameManager gameManager;
    [SerializeField] int count;
 
    [SerializeField] float charWaitTime = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        textUI.text = textToShow;
        escribir = true;
        count = 0;
        StartCoroutine(SlowlyShowText(textToShow));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && escribir == false && count == 1){
            Debug.Log("he pulsado el espacio.");
            StartCoroutine(SlowlyShowText(textcontinue));
            
        };
        if(Input.GetKeyDown(KeyCode.Space) && count == 2){
            gameManager.ChangeToNextScene();
            Debug.Log("pasa de escena");
        };
    }

    IEnumerator SlowlyShowText(string text){

        textUI.text = "";
        escribir = true;
        for (int i = 0; i < text.Length; i++){
            textUI.text += text[i];

            yield return new WaitForSeconds(charWaitTime);
        }
        escribir = false;
        count ++;
        Debug.Log(escribir);
        Debug.Log(count);
    }
}
