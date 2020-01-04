using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }
    Item currentlyEquippedItem;

    IWeapon equippedWeapon; //Save a couple of calls below

    Transform spawnProjectile;

    CharactersStats charactersStats;

    // Start is called before the first frame update
    void Start()
    {
        spawnProjectile = transform.Find("ProjectileSpawn"); //FindChild
        charactersStats = GetComponent<Player>().charactersStats;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerformWeaponAttack();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            PerformWeaponSpecialAttack();
        }
    }

    public void EquipWeapon(Item itemToEquip)
    {
        if (EquippedWeapon != null)
        {
            InventoryController.Instance.GiveItem(currentlyEquippedItem.ObjectSlug);
            charactersStats.RemoveBonusStats(EquippedWeapon.GetComponent<IWeapon>().Stats); //Remove current weapon's stats from player
            Destroy(playerHand.transform.GetChild(0).gameObject); //Destroy the current weapon on player's hand 
        }



        EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug), playerHand.transform.position, playerHand.transform.rotation);
        //Get the prefab named "Sword" from the "Resources" folder and set the weapon to the player's hand
        //The item is named "Sword" in InventoryController and this line will get the exact prefab for it 

        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();

        if (EquippedWeapon.GetComponent<IProjectileWeapon>() != null) //Sword can't cast fireball
        {
            EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = spawnProjectile;
        }

        EquippedWeapon.transform.SetParent(playerHand.transform); //Parent to the player's hand

        equippedWeapon.Stats = itemToEquip.Stats; //EquippedWeapon.GetComponent<IWeapon>().Stats; //Get stats from the weapon

        currentlyEquippedItem = itemToEquip;

        charactersStats.AddBonusStats(itemToEquip.Stats);

        UIEventHandler.ItemEquipped(itemToEquip);
        UIEventHandler.StatsChanged();
    }

    public void UnequipWeapon()
    {
        InventoryController.Instance.GiveItem(currentlyEquippedItem.ObjectSlug);
        charactersStats.RemoveBonusStats(equippedWeapon.Stats);
        Destroy(EquippedWeapon.transform.gameObject);
        UIEventHandler.StatsChanged();
    }

    public void PerformWeaponAttack() //Player performs a weapon attack
    {
        equippedWeapon.PerformAttack(CalculateDamage()); //EquippedWeapon.GetComponent<IWeapon>().PerformAttack();
    }

    public void PerformWeaponSpecialAttack() //Player performs a weapon attack
    {
        equippedWeapon.PerformSpecialAttack(); //EquippedWeapon.GetComponent<IWeapon>().PerformAttack();
    }

    private int CalculateDamage()
    {
        int damageToDeal = (charactersStats.GetStat(BaseStats.BaseStatType.Attack).GetCalculatedValue() * 2) + Random.Range(2, 8);
        damageToDeal += CalculatedCrit(damageToDeal);
        Debug.Log("Damage dealt: " + damageToDeal);
        return damageToDeal;
    }

    private int CalculatedCrit(int damage)
    {
        if (Random.value <= .10f) //10% Crit chance
        {
            int critDamage = (int)(damage * Random.Range(.5f, .75f));
            return critDamage;
        }
        return 0;
    }
}
