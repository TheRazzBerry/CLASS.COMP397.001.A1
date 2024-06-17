using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    private PlayerUI playerUI;
    private InputManager inputManager;

    [SerializeField] private float rayCastDistance = 3f;
    [SerializeField] private LayerMask mask;

    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        // Returned Information from Raycasting
        RaycastHit rayHitInfo;
        if (Physics.Raycast(ray, out rayHitInfo, rayCastDistance, mask))
        {
            if (rayHitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = rayHitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if (inputManager.general.Interact.triggered)
                {
                    interactable.baseInteract();
                }
            }
        }

        // Debug Testing
        Debug.DrawRay(ray.origin, ray.direction * rayCastDistance);
    }
}
