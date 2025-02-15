using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Merchants : MonoBehaviour
{

    private ItemSelector mItemSelector;
    [SerializeField] TextMeshProUGUI TextMeshPro;
    private GetInput getinput;
    private textAdd textadd;
    private GameObject imageObject;

    //
    public enum Human
    {
        Buyer,
        Seller
    }
    

    private int y;
    private int rate;
    private int firstValue;
    private int secondValue;
    private int finalValue;
    private int anger;
    //private int tolerance = 100;
    //private int minusTolerance;
    
    public Human human;

    public void Dialog()
    {
        mItemSelector=FindObjectOfType<ItemSelector>();
        getinput = FindObjectOfType<GetInput>();
        if (getinput == null)
        {
            Debug.LogError("GetInput script not found in the scene!");
        }
        
        
        switch (human)
        {
            case Human.Buyer:
                y= mItemSelector.RandomItem();
                if (y == 0)
                {
                    TextMeshPro.text=("Alabilecegim hicbir seyin yok.");
                    return;
                }

                rate = Random.Range(80, 120);
                firstValue = mItemSelector.ItemValue() * rate / 100;
                TextMeshPro.text = (mItemSelector.ItemName() + " Baya iyimis.");
                TextMeshPro.text += ("Senden bu esyayi alabilmek icin " + firstValue + " kadar altin verebilirim.");
                TextMeshPro.text += ("Ne dersin?");
                

                
                break;

            case Human.Seller:
                y = mItemSelector.RandomItem();
                if (mItemSelector.TotalLength() == 20)
                {
                    TextMeshPro.text = ("Sana esya satabilmem icin cantandani biraz bosaltmalisin.");
                    return;
                }

                TextMeshPro.text = ("Ilgini cekebilcek esyalarim var evlat.");
                rate = Random.Range(80, 120);
                firstValue = mItemSelector.ItemValue() * rate / 100;
                TextMeshPro.text = (mItemSelector.ItemName() + "'a bakmaya ne dersin?");
                TextMeshPro.text += ("bu esyayi " + firstValue + " altina satabilirim.");
                TextMeshPro.text += ("Ne dersin?");
                

                
                break;
        }
    }
    
 
    public void CounterOffer()
    {
        int no;
        int angerRate;
        secondValue = getinput.ReadInput();
        textadd = FindObjectOfType<textAdd>();
        
        imageObject = GameObject.Find(mItemSelector.items[y].itemName);
        switch(human)
        {
            case Human.Buyer:
                if (secondValue<= firstValue)
                {
                    TextMeshPro.text = (secondValue + " bu fiyata anlastik");

                    if (imageObject != null)
                    {
                        imageObject.SetActive(false);
                        mItemSelector.items.RemoveAt(y);
                    }
                    if (!int.TryParse(textadd.text1.text, out no))
                    {
                        Debug.Log("Deneme");
                    }
                    no += secondValue;
                    textadd.text1.text = no.ToString();
                }
                else
                {
                    angerRate = Mathf.Abs(secondValue - firstValue);
                    anger = Mathf.Clamp(angerRate / 100, 0, 10);
                    int averagePrice = (firstValue + secondValue) / 2;
                    finalValue = averagePrice - ((averagePrice - firstValue) * anger / 10);
                    //minusTolerance = tolerance * (firstValue - secondValue) / secondValue;
                    //finalValue = firstValue - (firstValue - secondValue) * (tolerance - minusTolerance) / 100;
                    Debug.Log(y + "   ");
                    Debug.Log(firstValue + " " + secondValue);
                    
                    TextMeshPro.text = (finalValue + " bu fiyata anlastik");


                    if (imageObject != null)
                    {
                        imageObject.SetActive(false);
                        mItemSelector.items.RemoveAt(y);
                    }
                    
                    if (!int.TryParse(textadd.text1.text, out no))
                    {
                        Debug.Log("Deneme");
                    }
                    no +=finalValue ;
                    textadd.text1.text = no.ToString();
                }
                break;

            case Human.Seller:
                /*if (secondValue >= firstValue)
                {
                    TextMeshPro.text = (secondValue + " bu fiyata anlastik");

                    if (imageObject != null)
                    {
                        imageObject.SetActive(false);
                        mItemSelector.items.RemoveAt(y);
                    }
                }*/
                //else
                //{
                    //minusTolerance = tolerance * (firstValue - secondValue) / secondValue;
                    //finalValue = firstValue - (firstValue - secondValue) * (tolerance - minusTolerance) / 100;
                    angerRate = Mathf.Abs(secondValue - firstValue);
                    anger = Mathf.Clamp(angerRate / 100, 0, 10);
                    int averageprice = (firstValue + secondValue) / 2;
                    finalValue = averageprice - ((averageprice - firstValue) * anger / 10);
                    Debug.Log(y + "   ");
                    Debug.Log(firstValue + " " + secondValue);
                    
                    TextMeshPro.text = (finalValue + " bu fiyata anlastik");
                


                    if (imageObject != null)
                    {
                        imageObject.SetActive(false);
                        mItemSelector.items.RemoveAt(y);
                    }
                    if (!int.TryParse(textadd.text1.text, out no))
                    {
                        Debug.Log("Deneme");
                    }
                    no +=-finalValue ;
                    textadd.text1.text = no.ToString();
                //}
                break;







        }
        
        // = tolerance * (totalValue - textValue) / textValue;

        /*if (minusTolerance > 70)
        {
            Debug.Log("Yuh");
        }
        else
        {
            */
        /*Debug.Log(y + "   ");
         Debug.Log(totalValue + " " + textValue);
         finalValue = totalValue - (totalValue - textValue) * (tolerance - minusTolerance) / 100;
         TextMeshPro.text=(finalValue + " bu fiyata anlastik");


         if (imageObject != null)
         {
                 imageObject.SetActive(false);
         }
         textadd.text1.text += finalValue.ToString();*/

    }
    public void Reset()
    {

        imageObject.SetActive (true);

    }
    public void Start()
    {
        mItemSelector = FindObjectOfType<ItemSelector>();
        int a = mItemSelector.TotalLength()-1;
        
        
        for (int i = 0; i < 20; i++)
        {
            imageObject = GameObject.Find(mItemSelector.itemsTest[i].itemName);
            imageObject.SetActive(false);
            imageObject.SetActive(true);
            if (i>a)
            {
                imageObject = GameObject.Find(mItemSelector.itemsTest[i].itemName);
                imageObject.SetActive(false);
            }
            
        }
        //
    }   

}