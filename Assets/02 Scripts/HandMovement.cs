using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;
    public float speed = 5.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //rb.AddForce(direction * speed, ForceMode2D.Force);
        rb.velocity = direction * speed;
    }

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("CHOCANDO CON " + collision.gameObject.name + "!!");
    }
}
