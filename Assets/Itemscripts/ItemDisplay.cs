using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemDisplay : MonoBehaviour
{
    public Item item;
    public Image ArtworkImage;
    void Start()
    {
        
        ArtworkImage.sprite = item.art;
    }


}
