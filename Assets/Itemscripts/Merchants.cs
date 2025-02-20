using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;
using UnityEngine.UI;
using TMPro;


public class Merchants : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextMeshPro;
    private ItemSelector mItemSelector;
    private GetInput getinput;
    private textAdd textadd;
    private GameObject imageObject;
    private SpriteLoader spriteLoader;
    
    public enum Human
    {
        Buyer,
        Seller
    }
    string name = ("Untitled 15");

    private int y;
    private int rate;
    private int firstValue;
    private int secondValue;
    private int finalValue;
    private int anger;


    private Human human;

    public void Dialog()
    {
        
        human = SelectionHuman();
        Debug.Log(SelectionHuman());


        mItemSelector = FindObjectOfType<ItemSelector>();
        getinput = FindObjectOfType<GetInput>();
        
        if (getinput == null)
        {
            Debug.LogError("GetInput!");
        }


        switch (human)
        {
            case Human.Buyer:
                y = mItemSelector.RandomItem();
                if (y == 0)
                {
                    TextMeshPro.text = ("Alabilecegim hicbir seyin yok.");
                    return;
                }

                rate = UnityEngine.Random.Range(80, 120);
                firstValue = mItemSelector.ItemValue() * rate / 100;
                TextMeshPro.text = (mItemSelector.ItemName() + " Baya iyimis.");
                TextMeshPro.text += ("Senden bu esyayi alabilmek icin " + firstValue + " kadar altin verebilirim.");
                TextMeshPro.text += ("Ne dersin?");
                spriteLoader.SpriteLoad(name);
                //spriteLoader.SpriteLoad(mItemSelector.ItemName());


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
                    spriteLoader.SpriteLoad(name);
                    //spriteLoader.SpriteLoad(mItemSelector.ItemNameTest());

                }


                break;
        }
    }


    public void CounterOffer()
    {
        
        if (TextMeshPro.text == null)
        {

        }
        else if (TextMeshPro.text == ("Bu is burda biter, dolandirici birader"))
        {

        }
        else if (TextMeshPro.text == ("bu fiyata anlastik"))
        {


        }

        else
        {


            
            int no;
            int angerRate;
            int temporary;
            secondValue = getinput.ReadInput();
            textadd = FindObjectOfType<textAdd>();

            
            switch (human)
            {
                
                case Human.Buyer:
                    imageObject = GameObject.Find(mItemSelector.items[y].itemName);
                    if (secondValue <= firstValue)
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
                        
                        spriteLoader.SpriteDeactive();
                        if (no>10000)
                        {
                            gameOver();
                        }
                        
                        
                    }
                    else if (secondValue >= firstValue * 3 / 2)
                    {
                        TextMeshPro.text = ("Bu is burda biter, dolandirici birader");
                        getinput.tmpInputField.text = null;
                        spriteLoader.SpriteDeactive();
                    }
                    else
                    {
                        int chance = UnityEngine.Random.Range(0, 6);
                        Debug.Log(chance);
                        if (chance == 0)
                        {
                            TextMeshPro.text = ("Bu is burda biter, dolandirici birader");
                            getinput.tmpInputField.text = null;
                            spriteLoader.SpriteDeactive();
                        }
                        else
                        {
                            angerRate = Mathf.Abs(secondValue - firstValue);
                            anger = Mathf.Clamp(angerRate / 100, 0, 10);
                            int averagePrice = (firstValue + secondValue) / 2;
                            temporary = finalValue;
                            finalValue = averagePrice - ((averagePrice - firstValue) * anger / 10);

                            Debug.Log(y + "   ");
                            Debug.Log(firstValue + " " + secondValue);
                            /*
                            if(temporary!=0)
                            {
                                if (secondValue <= temporary)
                                {
                                    temporary = 0;
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
                                    if (no > 10000)
                                    {
                                        gameOver();
                                    }

                                }



                            }
                            
                            else*/
                            TextMeshPro.text = (finalValue + " bu fiyata ne dersin?");
                        }




                    }
                    
                    break;

                case Human.Seller:
                    

                    int money;
                    if (!int.TryParse(textadd.text1.text, out money))
                    {
                        Debug.Log("Deneme");
                    }

                    imageObject = GameObject.Find(mItemSelector.itemsTest[y].itemName);
                    if (secondValue >= firstValue)
                    {
                        if (money < secondValue)
                        {
                            notEnoughMoney();
                            spriteLoader.SpriteDeactive();
                            getinput.tmpInputField.text = null;
                        }
                        else
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
                            
                            spriteLoader.SpriteDeactive();
                        }

                    }
                    else if (secondValue <= firstValue / 2)
                    {
                        TextMeshPro.text = ("Bu is burda biter, dolandirici birader");
                        getinput.tmpInputField.text = null;
                        spriteLoader.SpriteDeactive();
                    }
                    else
                    {
                        angerRate = Mathf.Abs(secondValue - firstValue);
                        anger = Mathf.Clamp(angerRate / 100, 0, 10);
                        int averageprice = (firstValue + secondValue) / 2;
                        Debug.Log(finalValue);
                        temporary = finalValue;
                        finalValue = averageprice - ((averageprice - firstValue) * anger / 10);
                        
                        Debug.Log(secondValue+" "+temporary);
                        /*
                        if(temporary!=0) 
                        {
                        if (secondValue >= temporary)
                        {
                            temporary = 0;
                            TextMeshPro.text = ("          bu fiyata anlastik");

                            if (imageObject != null)
                            {
                                imageObject.SetActive(false);
                                mItemSelector.items.RemoveAt(y);
                            }
                            if (!int.TryParse(textadd.text1.text, out no))
                            {
                                Debug.Log("Deneme");
                            }
                            no += -secondValue;
                            textadd.text1.text = no.ToString();

                        }
                        }
                        else*/
                        TextMeshPro.text = (finalValue + " bu fiyata ne dersin?");


                    }
                    
                    break;








            }

        }


    }
    public void Reset()
    {

        TextMeshPro.text = null;
        spriteLoader.SpriteDeactive();
        
    }
    public void DealAcceptance()
    {

        if (TextMeshPro.text == null)
        {

        }
        else if (TextMeshPro.text == ("Bu is burda biter, dolandirici birader"))
        {

        }
        else if (TextMeshPro.text == ("bu fiyata anlastik"))
        {


        }

        else
        {
            int no;
            switch (human)
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
                    spriteLoader.SpriteDeactive();
                    if (no > 10000)
                    {
                        gameOver();
                    }
                    break;


                case Human.Seller:
                    int money;
                    if (!int.TryParse(textadd.text1.text, out money))
                    {
                        Debug.Log("Deneme");

                    }
                    if (money < finalValue)
                    {
                        notEnoughMoney();
                        spriteLoader.SpriteDeactive();
                    }
                    else
                    {
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
                        spriteLoader.SpriteDeactive();
                    }
                    break;





            }

            Reset();
        }
        
    }
    private void notEnoughMoney()
    {
        int money;
        if (!int.TryParse(textadd.text1.text, out money))
        {
            Debug.Log("Deneme");
        }
        TextMeshPro.text = ("Fakirsin oglum sen");

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
    private Human SelectionHuman()
    {
        int selection = UnityEngine.Random.Range(0, 2);
        return (Human)selection;

    }
    private void gameOver()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
        
    }
    
    public void Start()
    {
        


        spriteLoader=FindAnyObjectByType<SpriteLoader>();
        

        Reset();

        
        mItemSelector = FindObjectOfType<ItemSelector>();
        mItemSelector.RandomizeItem();
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