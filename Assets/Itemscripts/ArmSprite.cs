using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSprite : MonoBehaviour
{
    private Sprite PrefabSprite;
    public GameObject Body;
    public GameObject Shoudler;
    public GameObject Forearm;
    public GameObject Hand;

    public void PrefabLoad()
    {
        int counter = Random.Range(1, 6);
        PrefabSprite = Resources.Load<Sprite>("Beden"+counter);
        Body.GetComponent<SpriteRenderer>().sprite = PrefabSprite;
        /*PrefabSprite = Resources.Load<Sprite>("Omuz"+counter);
        Shoudler.GetComponent<SpriteRenderer>().sprite = PrefabSprite;
        PrefabSprite = Resources.Load<Sprite>("Onkol"+counter);
        Forearm.GetComponent<SpriteRenderer>().sprite = PrefabSprite;
        PrefabSprite = Resources.Load<Sprite>("El"+counter);
        Hand.GetComponent<SpriteRenderer>().sprite = PrefabSprite;*/
    }
    
}
