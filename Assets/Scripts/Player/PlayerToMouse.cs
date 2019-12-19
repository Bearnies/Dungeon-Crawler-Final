using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerToMouse : MonoBehaviour
{
    public Transform player;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main; //Hold the main camera
        player = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Ray mousePos = mainCamera.ScreenPointToRay(Input.mousePosition); //Get mouse position on screen
        RaycastHit hit; //Store value of hit position

        //Make player look at mouse position without moving the position of player
        if (Physics.Raycast(mousePos, out hit, 100f))
        {
            Vector3 playerLookAtPos = new Vector3(hit.point.x, player.position.y, hit.point.z);
            player.LookAt(playerLookAtPos); //Look at position playerLookAtPos
        }
    }
}
