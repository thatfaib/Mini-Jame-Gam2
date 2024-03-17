using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetup : MonoBehaviour
{
    [SerializeField] ItemData VerticalPlant;
    [SerializeField] ItemData HorizontalPlant;
    [SerializeField] ItemData BouncePlant;
    [SerializeField] ItemData Shovel;
    [SerializeField] int VerticalPlants;
    [SerializeField] int HorizontalPlants;
    [SerializeField] int BouncePlants;
    [SerializeField] bool HasShovel;
    void Start()
    {   
        for(int i = 0; i < VerticalPlants; i++){
            InventoryScript.instance.AddItem(VerticalPlant);
        }
        for(int i = 0; i < HorizontalPlants; i++){
            InventoryScript.instance.AddItem(HorizontalPlant);
        }
        for(int i = 0; i < BouncePlants ;i++){
            InventoryScript.instance.AddItem(BouncePlant);
        }
        if(HasShovel){
            InventoryScript.instance.AddItem(Shovel);
        }
        
    }
}
