using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public RectTransform inventoryPanel;
    public RectTransform scrollViewContent;
    public RectTransform characterPanel;
    public RectTransform characterInfo;

    InventoryUIItem itemContainer { get; set; }
    bool menuIsActive { get; set; }
    bool infoIsActive { get; set; }
    Item currentSelectedItem { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        itemContainer = Resources.Load<InventoryUIItem>("UI/Item_Container");
        UIEventHandler.OnItemAddedToInventory += ItemAdded;
        inventoryPanel.gameObject.SetActive(false);
        characterPanel.gameObject.SetActive(false);

        characterInfo.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            menuIsActive = !menuIsActive;
            inventoryPanel.gameObject.SetActive(menuIsActive);
            characterPanel.gameObject.SetActive(menuIsActive);

            characterInfo.gameObject.SetActive(infoIsActive);
            infoIsActive = !infoIsActive;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            characterInfo.gameObject.SetActive(infoIsActive);
            infoIsActive = !infoIsActive;
        }
    }

    public void ItemAdded(Item item)
    {
        InventoryUIItem emptyItem = Instantiate(itemContainer);
        emptyItem.SetItem(item);
        emptyItem.transform.SetParent(scrollViewContent);
    }
}
