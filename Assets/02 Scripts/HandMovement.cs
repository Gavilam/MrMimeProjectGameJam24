using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;
    public float speed = 5.0f;
    public GameObject selectedPotion;

    [SerializeField] Transform cauldronHandTransform;
    [SerializeField] float animationDuration = 2;
    [SerializeField] AnimationCurve ease;
    [SerializeField] Sprite openHand;
    [SerializeField] Sprite closeHand;

    [SerializeField] AudioClip drop;
    [SerializeField] AudioSource source;

    SpriteRenderer spriteRenderer;
    Transform grabbedIngredient = null;

    bool canMove = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Events.TimeOver.AddListener(OnTimeOver);
    }

    private void FixedUpdate()
    {
        //rb.AddForce(direction * speed, ForceMode2D.Force);
        if (!canMove)
            return;

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

    public void SelectPotion()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (grabbedIngredient != null)
            return;
            
        Debug.Log("CHOCANDO CON " + collision.gameObject.name + "!!");
        if (collision.CompareTag("Ingredient"))
        {
            selectedPotion = collision.gameObject;
            spriteRenderer.sprite = closeHand;

            source.PlayOneShot(drop);

            StartCoroutine(MoveToCauldronCoroutine());

            grabbedIngredient = collision.transform;
            grabbedIngredient.parent.GetComponent<IngredientMovement>().IngredientGrabbed();
            grabbedIngredient.parent = transform;
        }
    }

    void OnTimeOver()
    {
        
    }

    IEnumerator MoveToCauldronCoroutine()
    {
        float elapsedTime = 0;
        Vector3 startingPosition = transform.position;
        canMove = false;
        rb.velocity = Vector2.zero;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startingPosition, cauldronHandTransform.position, ease.Evaluate(elapsedTime / animationDuration));

            yield return null;
        }

        canMove = true;

        ReleaseIngredient();
    }

    void ReleaseIngredient()
    {
        grabbedIngredient.parent = null;
        grabbedIngredient.gameObject.tag = "FallingIngredient";
        grabbedIngredient.GetComponent<Rigidbody2D>().gravityScale = 1;
        spriteRenderer.sprite = openHand;
    }
}
