using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelector : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private int index;

    public int RandomItem()
    {
        if (items.Count == 0) return 0;

        index = Random.Range(0, items.Count);
        return index;
    }

    public int TotalLength()
    {
        return items.Count;
        
    }

    public int ItemValue()
    {
        return items[index].value;
    }
    public string ItemName() 
    {  
        return items[index].name;
    }
    
}
