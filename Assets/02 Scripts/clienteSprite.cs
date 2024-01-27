using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clienteSprite : MonoBehaviour
{

    [SerializeField] Sprite spriteCliente;
    [SerializeField] int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 1;
        if(count == 1){
            
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteCliente;
            Debug.Log(spriteCliente);
        }else if(count == 2){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteCliente;
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
