using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;


public class ItemInteractionScript : MonoBehaviour
{
    [SerializeField] GameObject potPrefab;
    InventoryScript inventory;
    bool canPlant;
    bool canDestroyPlant;
    GameObject pot;
    GameObject plant;

    void Start(){
        inventory  = InventoryScript.instance;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && inventory.items.Count>0){
            ItemData item = inventory.items[inventory.selectedItem];
            if(canPlant && item.canBePlanted){ 
                Plant(pot, item); 
            }
            if(canDestroyPlant && item.id == 4){         
                Shovel(plant);
            }
        }
    }

    void Plant(GameObject pot, ItemData plant){
        pot.GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(plant.prefab,pot.transform.position,pot.transform.rotation);
        inventory.RemoveItem(plant);
        Destroy(pot);
        
    }

    void Shovel(GameObject plant){
        ItemData[] allItems = inventory.allItems;
        ItemData plantItem = allItems[0];
        Debug.Log(plant);  
        for(int i= 0; i< allItems.Length;i++){
            Debug.Log(allItems[i]);
            if(allItems[i].canBePlanted && allItems[i].prefab.name +"(Clone)" == plant.name){
                plantItem=allItems[i];
                break;

            }
        }
        inventory.AddItem(plantItem);
        Instantiate(potPrefab,plant.transform.position,plant.transform.rotation);
        Destroy(plant);

    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == LayerMask.NameToLayer("Töpfe")){
            pot = collision.gameObject;
            canPlant = true;
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("Plant")){
            plant = collision.gameObject;
            canDestroyPlant = true;
        }

    }
    void OnTriggerExit2D(Collider2D collision){
       if(collision.gameObject.layer == LayerMask.NameToLayer("Töpfe")){
            pot = null;
            canPlant = false;
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("Plant")){
            plant = null;
            canDestroyPlant = false;
        }

    }
}
