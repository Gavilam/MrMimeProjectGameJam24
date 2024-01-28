using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookContol : MonoBehaviour
{
    public Customer customer;
    [SerializeField] StorageScript storage;
    [SerializeField] SpriteRenderer bookRenderer;

    // Start is called before the first frame update
    void Start()
    {
        customer = GetCustomer();

        WritePage();
    }

    private void WritePage()
    {
        bookRenderer.sprite = customer.LibroReceta;
    }

    private Customer GetCustomer()
    {
        Debug.Log("Longitud = " + storage.customers.Length);
        Debug.Log("N = " + storage.n_customer);
        return storage.customers[storage.n_customer];
    }
}
