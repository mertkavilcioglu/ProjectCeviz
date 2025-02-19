using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLoader : MonoBehaviour
{
    private Sprite MySprite;

    public void SpriteLoad(string name)
    {
        MySprite = Resources.Load<Sprite>(name);
        if (MySprite == null)
        {
            Debug.LogError("Sprite not found! Check the path.");
        }
        GetComponent<SpriteRenderer>().sprite = MySprite;
    }

    
    public void SpriteDeactive()
    {
        GetComponent<SpriteRenderer>().sprite = null;

    }
}