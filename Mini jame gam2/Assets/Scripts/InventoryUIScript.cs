using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIScript : MonoBehaviour
{
    InventoryScript inventory;
    [SerializeField] Transform inventoryItems;
    InventoryUISlot[] slots;

    void Start()
    {
        inventory = InventoryScript.instance;
        inventory.onInventoryChangedCallback += UpdateInventoryUI;
        slots = inventoryItems.GetComponentsInChildren<InventoryUISlot>();
        UpdateInventoryUI();
    }

   
    public void UpdateInventoryUI()
    {
        int index = 0;
        foreach(ItemData item in inventory.items) {
            if(index == inventory.selectedItem){
                //slots[index].image.color = new Color(1,0,0,0.2f);
                Image childImage = slots[index].GetComponentsInChildren<Image>()[1];
                childImage.color = new Color(1f, 1f, 1f, 0.2f);
            }
            else{
                slots[index].image.color = new Color(1f,1f,1f,1f);
                Image childImage = slots[index].GetComponentsInChildren<Image>()[1];
                childImage.color = new Color(1f, 1f, 1f, 1f);
            }
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
