using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject itemPrefab;
    public float price;

    public char rarity;

    public string collection;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetPrice(float price)
    {
        this.price = price;
    }
    public void SetRarity(char rarity)
    {
        this.rarity = rarity;
    }
    public void SetCollection(string collection)
    {
        this.collection = collection;
    }
}
