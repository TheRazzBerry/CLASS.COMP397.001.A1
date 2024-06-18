using UnityEngine;

public class InteractableButton : Interactable
{
    private Material material;
    public bool isSwitched;

    [SerializeField] public GameProgressManager progressManager;

    void Start()
    {
        progressManager = GetComponent<GameProgressManager>();
        material = GetComponent<Renderer>().material;
        isSwitched = false;
        material.color = Color.red;
    }

    // Update is called once per frame
    protected override void Interact()
    {
        if (isSwitched) SwitchOff();
        else SwitchOn();
    }

    private void SwitchOn()
    {
        isSwitched = true;
        material.color = Color.green;
        progressManager.CheckState();
        Debug.Log(promptMessage + " Switched On");
    }

    private void SwitchOff()
    {
        isSwitched = false;
        material.color = Color.red;
        Debug.Log(promptMessage + " Switched Off");
    }
}
