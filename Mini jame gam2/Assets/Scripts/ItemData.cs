using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public int id;
    public string displayName;
    public Sprite icon;
    public GameObject prefab;
    public bool canBePlanted;


    public ItemData(int _id, string _displayName, Sprite _icon, GameObject _prefab, bool _canBePlanted){
        id = _id;
        displayName = _displayName;
        icon = _icon;
        prefab = _prefab;
        canBePlanted = _canBePlanted;
    }
}
