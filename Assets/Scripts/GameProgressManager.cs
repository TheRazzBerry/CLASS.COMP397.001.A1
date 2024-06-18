using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressManager : Interactable
{
    private Material material;

    [SerializeField] public InteractableButton SwitchA;
    [SerializeField] public InteractableButton SwitchB;
    [SerializeField] public InteractableButton SwitchC;

    [SerializeField] public GameObject exitDoor;

    [SerializeField] public bool isUnlocked;

    void Start()
    {
        SwitchA = GetComponent<InteractableButton>();
        SwitchB = GetComponent<InteractableButton>();
        SwitchC = GetComponent<InteractableButton>();

        material = GetComponent<Renderer>().material;
        exitDoor = GetComponent<GameObject>();

        isUnlocked = false;
    }

    public void CheckState()
    {
        if (SwitchA.isSwitched && SwitchB.isSwitched && SwitchC.isSwitched)
        {
            isUnlocked = true;
            material.color = Color.green;
        }
    }

    protected override void Interact()
    {
        Debug.Log("Attempted to open the exit gate!");
        if (isUnlocked)
        {
            Debug.Log("Attempted to destroy Exit Door!");
            Destroy(exitDoor);
        }
    }
}
