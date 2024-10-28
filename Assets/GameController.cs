using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject itemPrefab;
    public GameObject entityPrefab;
    private GameObject playerCharacter;

    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        InstantiateItem("nut", 100f);
        InstantiateItem("bread", 1f);
        InstantiateItem("uranium", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void InstantiateItem(string name, float price){
        GameObject newGameObject = Instantiate(itemPrefab);
        newGameObject.GetComponent<ItemController>().SetPrice(price);
        newGameObject.name = name;
        Debug.Log(newGameObject.name+" has been created with the price of "+ price);
    }
    void InstantiateEntity(string name, float price){
        GameObject newGameObject = Instantiate(itemPrefab);
        newGameObject.GetComponent<ItemController>().SetPrice(price);
        newGameObject.name = name;
        Debug.Log(newGameObject.name+" has been created with the price of "+ price);
    }
    void Transaction(GameObject seller, GameObject buyer, GameObject item, float offer){
        seller.GetComponent<EntityController>().sellItem(item, offer);
        buyer.GetComponent<EntityController>().buyItem(item, offer);
    }
}
