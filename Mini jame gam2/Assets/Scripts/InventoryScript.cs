using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public static InventoryScript instance;

    void Awake(){
        instance = this;
    }
   
    public delegate void OnInventoryChanged();
    public OnInventoryChanged onInventoryChangedCallback;

    public ItemData[] allItems;
    void Start(){
        allItems = Resources.FindObjectsOfTypeAll<ItemData>();
        allItems.OrderBy(item=>item.id);
    }

    public List<ItemData> items = new List<ItemData>(); 
    public int selectedItem = 0; 
    [SerializeField] int inventorySize = 4;

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
    
    public void selectNext(){
        selectedItem++;
        if(selectedItem >= items.Count){
            selectedItem=0;
        }
        if (onInventoryChangedCallback != null){
                onInventoryChangedCallback.Invoke();
        }
       
    }
    public void selectPrevious(){
        selectedItem--;
        if(selectedItem < 0){
            selectedItem = items.Count-1;
        }
        if (onInventoryChangedCallback != null){
                onInventoryChangedCallback.Invoke();
        }
       
    }
    
}
