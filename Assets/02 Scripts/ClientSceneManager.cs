using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSceneManager : MonoBehaviour
{
    public Customer customer;

    [SerializeField] StorageScript storage;
    [SerializeField] GameObject customer_object;

    // Start is called before the first frame update
    void Start()
    {
        customer = GetCustomer();
        //Events.CustomerReady?.Invoke();
        SetCustomer();
        LaunchCanvas();
    }

    private Customer GetCustomer()
    {
        return storage.customers[storage.n_customer];
    }

    private void SetCustomer()
    {
        customer_object.GetComponent<SpriteRenderer>().sprite = customer.image;
        customer_object.SetActive(true);
    }

    private void LaunchCanvas()
    {
        GetComponent<Timer>().StartTimer();
    }
}
