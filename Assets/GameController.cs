using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject itemPrefab;
    public GameObject entityPrefab;
    private GameObject playerCharacter;
    private GameObject activeNPC;
    private GameObject activeItem;

    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = InstantiateEntity(name:"Player Character",balance:1000);
        activeNPC = InstantiateEntity(name:"NPC");
        activeItem = InstantiateItem(name: "nut", price: 10, collection: "real_deal");
        activeNPC.GetComponent<EntityController>().addItem(activeItem);
        Transaction(activeNPC, playerCharacter, activeItem, 100);
        InstantiateItem("bread", 1f);
        InstantiateItem("uranium", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    GameObject InstantiateItem(string name, float price = 0, char rarity = 'a', string collection = "none")
    {
        GameObject newGameObject = Instantiate(itemPrefab);
        newGameObject.GetComponent<ItemController>().SetPrice(price);
        newGameObject.GetComponent<ItemController>().SetRarity(rarity);
        newGameObject.GetComponent<ItemController>().SetCollection(collection);
        newGameObject.name = name;
        Debug.Log(newGameObject.name + " has been created with" + " Price:" + price + " Rarity:" + rarity + " Collection:" + collection);
        return newGameObject;
    }
    GameObject InstantiateEntity(string name, float insight = 10, float deception = 10, float knowledge = 10, float balance = 0, bool playerCharacter = false)
    {
        GameObject newGameObject = Instantiate(entityPrefab);
        newGameObject.GetComponent<EntityController>().SetInsight(insight);
        newGameObject.GetComponent<EntityController>().SetDeception(deception);
        newGameObject.GetComponent<EntityController>().SetKnowledge(knowledge);
        newGameObject.GetComponent<EntityController>().SetBalance(balance);
        newGameObject.GetComponent<EntityController>().SetPlayerCharacter(playerCharacter);
        newGameObject.name = name;
        Debug.Log(newGameObject.name + " has been created with" + " Insight:" + insight + " Deception:" + deception + " Knowledge:" + knowledge + " Balance:" + balance + " Is Player Character:" + playerCharacter);
        return newGameObject;
    }
    void Transaction(GameObject seller, GameObject buyer, GameObject item, float offer)
    {
        seller.GetComponent<EntityController>().sellItem(item, offer);
        buyer.GetComponent<EntityController>().buyItem(item, offer);
    }
}
