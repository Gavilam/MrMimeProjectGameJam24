using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextWindow : MonoBehaviour
{
    [SerializeField] TMP_Text textUI;
    [SerializeField] string textToShow;
    [SerializeField] string textcontinue;
 
    [SerializeField] float charWaitTime = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        textUI.text = textToShow;

        StartCoroutine(SlowlyShowText(textToShow));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("he pulsado el espacio.");
            StartCoroutine(SlowlyShowText(textcontinue));
        };
    }

    IEnumerator SlowlyShowText(string text){

        textUI.text = "";

        for (int i = 0; i < text.Length; i++){
            textUI.text += text[i];

            yield return new WaitForSeconds(charWaitTime);
        }
    }
}
