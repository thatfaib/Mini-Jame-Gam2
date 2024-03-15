using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    [SerializeField] InventoryUIScript UI;
    [SerializeField] int inventorySize = 4;

    public static InventoryScript instance;

    void Awake(){
        instance = this;
    }

    public List<ItemData> items = new List<ItemData>();       
    public delegate void OnInventoryChanged();
    public OnInventoryChanged onInventoryChangedCallback;

    public void AddItem(ItemData itemToAdd){
        if(items.Count < inventorySize) {
            items.Add(itemToAdd);
            if (onInventoryChangedCallback != null){
                onInventoryChangedCallback.Invoke();
            }
        }       
    }

    public void RemoveItem(ItemData itemToRemove) {
        items.Remove(itemToRemove);
        if (onInventoryChangedCallback != null){
                onInventoryChangedCallback.Invoke();
        }
    }
    
    
}
