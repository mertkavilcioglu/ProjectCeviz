using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelector : MonoBehaviour
{
    public Item[] items;

    private int Index;
    public int RandomItem()
    {
        if (items.Length == 0) return 0;

        else
        {
        Index = Random.Range(0, items.Length);
        
        return Index;
        }
    }   
    public int TotalLength()
    {
        return items.Length;
    }

    public int ItemValue()
    {
        return items[Index].value;
    }
    public string ItemName() 
    {  
        return items[Index].name;
    }
    void Start()
    {
        
    }
}
