using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portal : ActionItem
{
    public Vector3 TeleportFrom { get; set; }

    [SerializeField] private Portal[] portals;

    private PortalController PortalController;

    // Start is called before the first frame update
    void Start()
    {
        TeleportFrom = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z);
        PortalController = FindObjectOfType<PortalController>();
    }

    public override void Interact()
    {
        PortalController.OnActivatePortal(portals);
        playerAgent.ResetPath(); //Remove the Path as the destination
    }
}
