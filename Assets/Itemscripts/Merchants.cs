using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchants : ItemSelector
{
    public enum Human
    {
        Buyer,
        Seller
    }
    

    
   
    private int rate;
    private int totalValue;
    public Human human;
    void Start()
    {
        
        switch (human)
        {
            case Human.Buyer:
                if(RandomItem()==0)
                {
                    Debug.Log("Alabilecegim hicbir seyin yok.");
                }
                else
                {
                    
                    rate=Random.Range(80, 120);
                    totalValue = ItemValue()*rate/100;
                    Debug.Log(ItemName()+" Baya iyimis");
                    Debug.Log("Sana bu esya icin " + totalValue + " kadar para verebilirim");
                    Debug.Log("Ne dersin?");
                }
                break;
                
            case Human.Seller:
                if(TotalLength()==20)
                {
                    Debug.Log("Sana esya satabilmem icin cantandani biraz bosaltmalisin.");
                }
                else
                {
                    Debug.Log("Ilgini cekebilcek esyalarim var evlat");
                }
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
