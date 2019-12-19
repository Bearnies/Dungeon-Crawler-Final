using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public Item sword;

    public PlayerWeaponController playerWeaponController;

    // Start is called before the first frame update
    void Start()
    {
        playerWeaponController = GetComponent<PlayerWeaponController>();
        List<BaseStats> swordStats = new List<BaseStats>();
        swordStats.Add(new BaseStats(6, "Attack", "Your attack power"));
        sword = new Item(swordStats, "Staff");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            playerWeaponController.EquipWeapon(sword);
        }
    }
}
