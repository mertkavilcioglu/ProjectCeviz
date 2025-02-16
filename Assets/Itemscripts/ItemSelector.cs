using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelector : MonoBehaviour
{
   

    public List<Item> items = new List<Item>();
    public List<Item> itemsTest = new List<Item>();

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
    public int RandomItemTest()
    {
        if (itemsTest.Count == 0) return 0;
        index = Random.Range(0, itemsTest.Count);
        return index;
    }

    public int TotalLengthTest()
    {
        return itemsTest.Count;

    }

    public int ItemValueTest()
    {
        return itemsTest[index].value;
    }
    public string ItemNameTest()
    {
        return itemsTest[index].name;
    }

}
