using UnityEngine.UI;

using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] Image icon;
    ItemData item;  

    public void AddItemToSlot(ItemData newItem){
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    
    }

    public void ClearItemslot(){
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    
    }

    void Awake() {
        ClearItemslot();
    }
}
