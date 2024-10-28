using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    private bool playerCharacter;
    private float insight;
    private float knowledge;
    private float deception;
    [SerializeField] float balance;
    [SerializeField] float startingBalance;
    [SerializeField] List<GameObject> items = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public float GetInsight(){
        return insight;
    }
    public float GetDeception(){
        return deception;
    }
    public float GetKnowledge(){
        return knowledge;
    }
    public float GetBalance(){
        return balance;
    }
    public bool HasItem(GameObject item)
    {
        return items.Contains(item);
    }

    public void addItem(GameObject item)
    {
        items.Add(item);
        Debug.Log(gameObject.name + ":" + item.name + " has been added");
    }
    public void removeItem(GameObject item)
    {
        if (HasItem(item))
        {
            items.Remove(item);
            Debug.Log(gameObject.name + ":" + item.name + " has been removed");
        }
        else
        {
            Debug.Log(gameObject.name + ":" + item.name + " doesn't exist");
        }

    }
     public void buyItem(GameObject item, float offer)
    {
        if (balance >= offer)
        {
            addItem(item);
            balance -= offer;
            Debug.Log(gameObject.name + ":" + item.name + " has been bought for " + offer);
        }
        else
        {
            Debug.Log(gameObject.name + ":" + " Doesn't have enough money to complete the transaction");
        }
    }
    public void sellItem(GameObject item, float offer)
    {
        if (HasItem(item))
        {
            removeItem(item);
            balance += offer;
            Debug.Log(gameObject.name + ":" + item.name + " has been sold for " + offer);
        }
        else
        {
            Debug.Log(gameObject.name + ":" + " doesn't have the item");
        }
    }
}
