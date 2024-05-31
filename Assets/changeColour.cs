using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColour : MonoBehaviour
{
    private Material material;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.GetComponent<Renderer>().material = material;
            material.color = Color.red;
            StartCoroutine(BackToOgColor());
        }
    }
    IEnumerator BackToOgColor()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Renderer>().material = material;
        material.color = Color.white;
    }
   
}
