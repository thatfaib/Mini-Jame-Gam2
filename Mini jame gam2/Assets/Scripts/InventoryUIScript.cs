using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUIScript : MonoBehaviour
{
    InventoryScript inventory;
    [SerializeField] Transform inventoryItems;
    InventorySlot[] slots;

    void Start()
    {
        inventory = InventoryScript.instance;
        inventory.onInventoryChangedCallback += UpdateInventoryUI;
        slots = inventoryItems.GetComponentsInChildren<InventorySlot>();
        UpdateInventoryUI();
    }

   
    public void UpdateInventoryUI()
    {
        int index = 0;
        foreach(ItemData item in inventory.items) {
            slots[index].AddItemToSlot(item);
            index++;
        }
        if(index < slots.Length){
            for(int i = index; i<slots.Length;i++){
                slots[i].ClearItemslot();
            }

        }
    }
}
