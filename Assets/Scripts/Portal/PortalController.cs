﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalController : MonoBehaviour
{
    [SerializeField]
    private Button button;
    private Portal[] portal;
    private Player player;
    private GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        panel = transform.Find("Panel_Portals").gameObject;
    }

    public void OnActivatePortal (Portal[] portals)
    {
        panel.SetActive(true);
        for (int i = 0; i < portals.Length; i++)
        {
            Button portalButton = Instantiate(button, panel.transform);
            portalButton.GetComponentInChildren<Text>().text = portals[i].name;
            int portalIndex = i;
            portalButton.onClick.AddListener(delegate { OnPortalButtonClick(portalIndex, portals[portalIndex]); });
        }
    }

    public void OnPortalButtonClick (int portalIndex, Portal portal)
    {
        player.transform.position = portal.TeleportFrom;
        foreach (Button button in GetComponentsInChildren<Button>())
        {
            Destroy(button.gameObject);
        }
        panel.SetActive(false);
    }
}