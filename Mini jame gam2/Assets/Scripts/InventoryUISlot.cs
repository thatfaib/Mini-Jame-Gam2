using UnityEngine.UI;

using UnityEngine;

public class InventoryUISlot : MonoBehaviour
{   
    [SerializeField] Image icon;
    public Image image;
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

       // image.color = new Color(0,0,0,0.8f);
    
    }

    void Awake() {
        ClearItemslot();
    }
}
