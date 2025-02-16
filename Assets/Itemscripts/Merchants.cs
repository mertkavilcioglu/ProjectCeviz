using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System;
using System.Linq;

public class Merchants : MonoBehaviour
{
    private ItemSelector mItemSelector;
    [SerializeField] TextMeshProUGUI TextMeshPro;
    private GetInput getinput;
    private textAdd textadd;
    private GameObject imageObject;

    
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

                rate = UnityEngine.Random.Range(80, 120);
                firstValue = mItemSelector.ItemValue() * rate / 100;
                TextMeshPro.text = (mItemSelector.ItemName() + " Baya iyimis.");
                TextMeshPro.text += ("Senden bu esyayi alabilmek icin " + firstValue + " kadar altin verebilirim.");
                TextMeshPro.text += ("Ne dersin?");
                

                
                break;

            case Human.Seller:
                
                if (mItemSelector.TotalLength() == 20)
                {
                    TextMeshPro.text = ("Sana esya satabilmem icin cantandani biraz bosaltmalisin.");
                    
                }
                else
                { 
                y = mItemSelector.RandomItemTest();
                while (mItemSelector.items.Exists(item => item.itemName == mItemSelector.itemsTest[y].itemName))
                {
                    y = mItemSelector.RandomItemTest();
                }

                TextMeshPro.text = ("Ilgini cekebilcek esyalarim var evlat.");
                rate = UnityEngine.Random.Range(80, 120);
                firstValue = mItemSelector.ItemValueTest() * rate / 100;
                TextMeshPro.text = (mItemSelector.ItemNameTest() + "'a bakmaya ne dersin?");
                TextMeshPro.text += ("bu esyayi " + firstValue + " altina satabilirim.");
                TextMeshPro.text += ("Ne dersin?");
                }


                break;
        }
    }
    
 
    public void CounterOffer()
    {
        if(TextMeshPro.text == null)
        { 
        
        }
        else if(TextMeshPro.text == ("Bu is burda biter, dolandirici birader"))
        {

        }
        else if(TextMeshPro.text == ("bu fiyata anlastik"))
        {


        }
            
        else
        {
            
        

        int no;
        int angerRate;
        secondValue = getinput.ReadInput();
        textadd = FindObjectOfType<textAdd>();
        
        
        switch(human)
        {
            case Human.Buyer:
                    imageObject = GameObject.Find(mItemSelector.items[y].itemName);
                if (secondValue<= firstValue)
                {
                    TextMeshPro.text = ("bu fiyata anlastik");

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
                else if(secondValue>=firstValue*3/2)
                    {
                        TextMeshPro.text = ("Bu is burda biter, dolandirici birader");
                    }
                else
                {
                    angerRate = Mathf.Abs(secondValue - firstValue);
                    anger = Mathf.Clamp(angerRate / 100, 0, 10);
                    int averagePrice = (firstValue + secondValue) / 2;
                    finalValue = averagePrice - ((averagePrice - firstValue) * anger / 10);
                    
                    Debug.Log(y + "   ");
                    Debug.Log(firstValue + " " + secondValue);
                    TextMeshPro.text = (finalValue + " bu fiyata ne dersin?");



                }
                break;

            case Human.Seller:
                    imageObject = GameObject.Find(mItemSelector.itemsTest[y].itemName);
                    if (secondValue >= firstValue)
                    {
                        TextMeshPro.text = (secondValue + " bu fiyata anlastik");
                        if (!int.TryParse(textadd.text1.text, out no))
                        {
                            Debug.Log("Deneme");
                        }
                        no += -secondValue;
                        textadd.text1.text = no.ToString();

                        if (imageObject == null)
                        {
                            FindingDisabled();
                            mItemSelector.items.Add(mItemSelector.itemsTest[y]);

                        }
                        

                    }
                    else if (secondValue <= firstValue / 2)
                    {
                        TextMeshPro.text = ("Bu is burda biter, dolandirici birader");
                    }
                    else
                    {
                        angerRate = Mathf.Abs(secondValue - firstValue);
                        anger = Mathf.Clamp(angerRate / 100, 0, 10);
                        int averageprice = (firstValue + secondValue) / 2;
                        finalValue = averageprice - ((averageprice - firstValue) * anger / 10);
                        Debug.Log(y + "   ");
                        Debug.Log(firstValue + " " + secondValue);
                        TextMeshPro.text = (finalValue + " bu fiyata ne dersin?");


                    }
                break;
                    






         
        }
            
        }


    }
    public void Reset()
    {

        TextMeshPro.text = null;
    }
    public void DealAcceptance()
    {
        
        if (TextMeshPro.text == null)
        { 
        
        }
        else if(TextMeshPro.text == ("Bu is burda biter, dolandirici birader"))
        {

        }
        else if (TextMeshPro.text == ("bu fiyata anlastik"))
        {


        }

        else
        {
            int no;
        switch(human)
        {
            case Human.Buyer:
                TextMeshPro.text = (finalValue + " bu fiyata anlastik");
                if (imageObject != null)
                {
                    imageObject.SetActive(false);
                    mItemSelector.items.RemoveAt(y); ;
                }
                if (!int.TryParse(textadd.text1.text, out no))
                {
                    Debug.Log("Deneme");
                }
                no += finalValue;
                textadd.text1.text = no.ToString();
                break;


            case Human.Seller:
                TextMeshPro.text = (finalValue + " bu fiyata anlastik");
                if (!int.TryParse(textadd.text1.text, out no))
                {
                    Debug.Log("Deneme");
                }
                no += -finalValue;
                textadd.text1.text = no.ToString();
                if (imageObject == null)
                {
                        FindingDisabled();
                        mItemSelector.items.Add(mItemSelector.itemsTest[y]);
                }
                
                break ;





        }
            Reset();
        }
    }
    
    private void FindingDisabled()
    {
        ItemDisplay[] allObjects = FindObjectsOfType<ItemDisplay>(true); 

        foreach (ItemDisplay obj in allObjects)
        {
            if (obj.gameObject.name == mItemSelector.itemsTest[y].itemName)
            {
                GameObject myDisabledObject = obj.gameObject;
                myDisabledObject.SetActive(true);
            }
        }
    }
    public void Start()
    {
        
        Reset();
        

        mItemSelector = FindObjectOfType<ItemSelector>();
        int a = mItemSelector.TotalLength();

        for (int i = 0; i < 20; i++)
        {
            GameObject subobject = GameObject.Find(mItemSelector.itemsTest[i].itemName);
            if (mItemSelector.items.Exists(item => item.itemName == mItemSelector.itemsTest[i].itemName))
            {
                Debug.Log("BLABLA");
            }
            else
            {
                subobject.SetActive(false);
            }
        }




    }   

}