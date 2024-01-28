using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextWindow : MonoBehaviour
{
    [SerializeField] TMP_Text customerTextBox;
    [SerializeField] TMP_Text shopkeeperTextBox;
    [SerializeField] Customer customer;
    [SerializeField] string magaDialogo;
    [SerializeField] FlowManager flowManager;
    int count = 0;
 
    [SerializeField] float charWaitTime = 0.05f;
    Coroutine coroutine = null;

    // Start is called before the first frame update
    void Start()
    {
        magaDialogo = "Se lo que necesitas!";

        //diálogo 1 zarigüeya: Me han echado tremenda maldision.
        //diálogo 2 zarigüeya: ¿Puedes revertir sus efectos?

        //diálogo 1 chaval:Poh favoh, kiero zermah duro..
        //diálogo 2 chaval:por fi..
        
        //StartCoroutine(SlowlyShowText(textToShow));

        customerTextBox.transform.parent.gameObject.SetActive(false);
        shopkeeperTextBox.transform.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (coroutine != null)
            return;

        if(Input.GetKeyDown(KeyCode.Space)){
            if (count > customer.textos.Length)
                flowManager.ChangeToNextScene();
            else
                coroutine = StartCoroutine(SlowlyShowText());
        };

    }

    IEnumerator SlowlyShowText(){

        string textToShow = "";
        TMP_Text textUI = null;

        if (count == customer.textos.Length){
            textToShow = magaDialogo;
            textUI = shopkeeperTextBox;
            
            customerTextBox.transform.parent.gameObject.SetActive(false);
            shopkeeperTextBox.transform.parent.gameObject.SetActive(true);
        }
        else{
            textToShow = customer.textos[count];
            textUI = customerTextBox;

            customerTextBox.transform.parent.gameObject.SetActive(true);
            shopkeeperTextBox.transform.parent.gameObject.SetActive(false);
        }

        textUI.text = "";

        for (int i = 0; i < textToShow.Length; i++){
            textUI.text += textToShow[i];

            yield return new WaitForSeconds(charWaitTime);
        }
        
        count++;
        Debug.Log("frase dicha");
        Debug.Log(count);

        coroutine = null;
    }
}