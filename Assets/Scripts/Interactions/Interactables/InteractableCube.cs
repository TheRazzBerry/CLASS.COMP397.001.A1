using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableCube : Interactable
{
    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        material.color = Color.white;
    }

    protected override void Interact()
    {
        if (material.color != Color.white)
        {
            material.color = Color.white;
        }
        else
        {
            material.color = Color.red;
        }
        Debug.Log("Interacted with " + gameObject.name);
    }
}
