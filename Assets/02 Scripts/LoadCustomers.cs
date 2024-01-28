using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCustomers : MonoBehaviour
{
    [SerializeField] Customer[] customerList;
    [SerializeField] StorageScript storage;

    // Start is called before the first frame update
    void Start()
    {
        LoadCustomerList();
    }

    public void LoadCustomerList()
    {
        storage.customers = customerList;
        storage.n_customer = 0;
    }
}
