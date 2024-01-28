using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientMovement : MonoBehaviour
{
    [SerializeField] Transform ingredient;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] float halfDuration;
    [SerializeField] AnimationCurve ease;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AnimationCoroutine());
    }

    
    IEnumerator AnimationCoroutine()
    {
        float t;

        while (true)
        {
            t = 0;

            while (t < halfDuration)
            {
                t += Time.deltaTime;
                ingredient.position = Vector3.Lerp(pointA.position, pointB.position, ease.Evaluate(t / halfDuration));

                yield return null;
            }

            t = 0;

            while (t < halfDuration)
            {
                t += Time.deltaTime;
                ingredient.position = Vector3.Lerp(pointB.position, pointA.position, ease.Evaluate(t / halfDuration));

                yield return null;
            }
        }
    }


    public void IngredientGrabbed()
    {
        StopAllCoroutines();
    }
}
