using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemList", menuName = "ScriptableObjects/ItemList")]
public class ItemList : ScriptableObject
{
    public List<Item> items = new List<Item>();
}